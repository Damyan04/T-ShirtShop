using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Data;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Services.Data;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TShirtShop.Data.Models.Enums;

namespace TShirtShop.Services
{
    public class UploadFileService : IUploadFileService
    {
        private const int lastItems = 3;
        private readonly ApplicationDbContext _appDbContext;
        public UploadFileService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<string> GetAllUserImg(string userId)
        {
            var validuserId = _appDbContext.Users.Select(u => u.Id == userId).FirstOrDefault();
            if (userId != null)
            {
                var images = _appDbContext.Users.Where(a => a.Id == userId).Select(a => a.DesignPictures).FirstOrDefault();
                if (images != null)
                {
                    List<string> imageIds = images.OrderByDescending(a=>a.CreatedOn).Select(a => a.Id).ToList();

                    return imageIds;
                }
               

            }
            return null;

        }

        public void AddImageForUser(IList<IFormFile> files, string userId)
        {
            var validuserId = _appDbContext.Users.Select(u => u.Id == userId).FirstOrDefault();
            if (validuserId)
            {


                IFormFile uploadedImage = files.FirstOrDefault();
                if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
                {

                    MemoryStream ms = new MemoryStream();
                    uploadedImage.OpenReadStream().CopyTo(ms);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                    DesignImage imageEntity = new DesignImage()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = uploadedImage.Name,
                        Data = ms.ToArray(),
                        Width = 100,
                        Height = 100,
                        ContentType = uploadedImage.ContentType,
                        UserId = userId

                    };

                    _appDbContext.DesignImages.Add(imageEntity);

                    _appDbContext.SaveChanges();
                    var images = GetAllImgForUser(userId);
                    DeleteLastItem(images);
                }

            }
        }
        public ICollection<string> GetAllSizes()
        {
            string[] names = Enum.GetNames(typeof(Sizes));
            return names;
        }
        public FileStreamResult ViewImage(string imageId)
        {
            DesignImage image = _appDbContext.DesignImages.FirstOrDefault(m => m.Id == imageId);

            MemoryStream ms = new MemoryStream(image.Data);

            return new FileStreamResult(ms, image.ContentType);
        }
        private ICollection<DesignImage> GetAllImgForUser(string userId) 

            {

            var images = _appDbContext.Users.Where(a => a.Id == userId).Select(a => a.DesignPictures).FirstOrDefault();
            return images;


        }
            private void DeleteLastItem(ICollection<DesignImage> images)
            {
            
                if (images.Count > lastItems)
                {
                    var lastImg = images.OrderByDescending(a => a.CreatedOn).LastOrDefault();
                    _appDbContext.DesignImages.Remove(lastImg);
                    _appDbContext.SaveChanges();
                }


            }
        }
    }
        

            
          

        
    
