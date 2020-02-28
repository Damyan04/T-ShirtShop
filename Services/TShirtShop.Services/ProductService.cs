using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TShirtShop.Data;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Data.Models.Enums;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _appDbContext;
        public ProductService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ProductDto GetProductById(string productId)
        {
            var data = _appDbContext.Products.FirstOrDefault(p => p.Id == productId);

            if (data != null)
            {
                var productDto = MapProduct(data);
                return productDto;
            }
            return null;
        }

        public ICollection<ProductDto> Products()
        {
            var data = _appDbContext.Products.Include(c => c.Tags).ToList();
            var products = MapCollectionProducts(data);
            return products;


        }
        public ICollection<TagDto> GetTags()
        {
            var data = _appDbContext.Tags.ToList();
            ICollection<TagDto> tags = MapTagList(data);
            //  var products = MapCollectionProducts(data);
            return tags;


        }
        public ICollection<ProductDto> NewestProducts()
        {
            ICollection<Product> data = _appDbContext.Products.OrderByDescending(c => c.CreatedOn).ToList();
            ICollection<ProductDto> products = MapCollectionProducts(data);
            return products;


        }
        public FileStreamResult ViewProduct(string imageId)
        {
            var image = _appDbContext.Images.FirstOrDefault(m => m.Id == imageId);

            MemoryStream ms = new MemoryStream(image.Data);

            return new FileStreamResult(ms, image.ContentType);
        }
      public void PostComment(string rating, string textAnswer,string productId,string userId)
        {
            if (rating == null) { rating = "0"; }
            if (textAnswer == null)
            {
                return;
            }
            var review = new Review()
            {
                Id = Guid.NewGuid().ToString(),
                Stars = double.Parse(rating),
                Comment = textAnswer,
                ProductId = productId,
                UserId = userId,

            };
            _appDbContext.Reviews.Add(review);
            _appDbContext.SaveChanges();
        }
        private string GetUserName(string id)
        {
            var userName=_appDbContext.Users.Where(a => a.Id == id).Select(b=>b.UserName).FirstOrDefault();
            return userName;
        }
       private ICollection<ReviewDto> GetComments( string productId)
        {
            var comments = _appDbContext.Reviews.OrderByDescending(a=>a.CreatedOn).ToList();
             IList<ReviewDto> reviews= new List<ReviewDto>();
            foreach (var review in comments)
            {
                var commentToAdd = new ReviewDto()
                {
                    Id=review.Id,
                    Comment=review.Comment,
                    CreatedOn=review.CreatedOn,
                    ModifiedOn=review.ModifiedOn,
                    ProductId=review.ProductId,
                    Stars=review.Stars,
                    UserId=review.UserId,
                    UserName=GetUserName(review.UserId)
                    
                };
                reviews.Add(commentToAdd);
            }
            return reviews;
        }
        public void AddImage(ICollection<IFormFile> files, string name, string price, IList<string> colors, IList<string> tags, IList<string> sizes, string className)
        {
          
            IFormFile uploadedImage = files.FirstOrDefault();
            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {

                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                Image imageEntity = new Image()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = uploadedImage.Name,
                    Data = ms.ToArray(),
                    Width = 100,
                    Height = 100,
                    ContentType = uploadedImage.ContentType,


                };
                var product = new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    PictureId = imageEntity.Id,
                    Picture = imageEntity,
                    Price = double.Parse(price),
                   
                   
                Class = className

                };
                
                foreach (var colorName in colors)
                {
                    try
                    {
                        var color = (Colors)Enum.Parse(typeof(Colors), colorName);
                        var colour = new Color()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Colors = color
                        };
                        product.ColorsList.Add(colour);
                    }
                    catch
                    {

                    }
                    }
                   
                
                foreach (var sizeName in sizes)
                {
                    try
                    {
                        var actualSize = (Sizes)Enum.Parse(typeof(Sizes), sizeName);
                        var size = new Size()
                        {
                            Id = Guid.NewGuid().ToString(),
                            SizeName = actualSize
                        };
                        product.SizeList.Add(size);
                    }
                    catch
                    {

                    }
                    
                }
                //TODO:Check for existing tag name
                foreach (var item in tags)
            {
                var tag = new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = item,
                    Class = className
                };
                product.Tags.Add(tag);
                _appDbContext.Tags.Add(tag);
            }

            _appDbContext.Products.Add(product);
            _appDbContext.Images.Add(imageEntity);

            _appDbContext.SaveChanges();

        }

    }
        private ICollection<string> GetColorsForProduct(string productId)
        {
            var actualColors = _appDbContext.Products.Where(a => a.Id == productId).Select(a => a.ColorsList).FirstOrDefault();
           
            var list = new List<string>();
            foreach (var item in actualColors)
            {
                var color = item.Colors.ToString("F");
                list.Add(color);
    }
            return list;
            }
        


        private ICollection<TagDto>MapTagList(ICollection<Tag> data)
        {
            
            ICollection<TagDto>tagDtos = new HashSet<TagDto>();
            foreach (var tag in data)
            {
                var tagDto = new TagDto()
                {

                    Id = tag.Id,
                    Name = tag.Name,
                    CreatedOn = tag.CreatedOn,
                    ModifiedOn = tag.ModifiedOn,
                    
                    Class = tag.Class
                    


                };
                tagDtos.Add(tagDto);
            }
            return tagDtos;
        }
            private ICollection<ProductDto> MapCollectionProducts(ICollection<Product> data)
        {
            
            ICollection<ProductDto> productDtos = new HashSet<ProductDto>();
            foreach (var product in data)
            {
              
                var picture = _appDbContext.Images.Where(a => a.Id == product.PictureId).FirstOrDefault();
                var image = new ImageDto()
                {
                    Name= picture.Name,
                    ContentType= picture.ContentType,
                    Data= picture.Data,
                    Id= picture.Id,
                    CreatedOn= picture.CreatedOn,
                    ModifiedOn= picture.ModifiedOn,
                    Height= picture.Height,
                    Length= picture.Length,
                    Width= picture.Width

                };

                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                   
                    PictureId = product.PictureId,
                    Picture = image,
                    Price = product.Price,
                    SizeList = new HashSet<string>(),
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn,
                    Tags = new HashSet<TagDto>(),
                      Class = product.Class,
                      ColorsList = GetColorsForProduct(product.Id),
                      Reviews = GetComments(product.Id)


                };
                //foreach (var colorName in product.ColorsList)
                //{
                //    var color = colorName.Colors.ToString("F");
                //    productDto.ColorsList.Add(color);
                //}
                foreach (var sizeName in product.SizeList)
                {
                    var size = sizeName.SizeName.ToString("F");
                    productDto.SizeList.Add(size);
                }
              
                foreach (var tag in product.Tags)
                {
                    var tagDto = new TagDto()
                    {

                        Id = tag.Id,
                        Name = tag.Name,
                        CreatedOn =tag.CreatedOn,
                        ModifiedOn = tag.ModifiedOn,
                        Class = tag.Class


                    };
                    productDto.Tags.Add(tagDto);

                }
                productDtos.Add(productDto);
            }
            return productDtos as ICollection<ProductDto>;
        }
       
        private ProductDto MapProduct(Product data)
        {
          
            var productDto = new ProductDto()
            {
                Id = data.Id,
                Name = data.Name,

                PictureId = data.PictureId,
                Price = data.Price,
                SizeList = new HashSet<string>(),
                CreatedOn = data.CreatedOn,
                ModifiedOn = data.ModifiedOn,
                Class = data.Class,
                ColorsList = GetColorsForProduct(data.Id),
                 Reviews = GetComments(data.Id)
            };
           // var colorsList = _appDbContext.Colors.Where(a => a.ProductId == data.Id).OrderByDescending(a=>a.Colors).ToList();
            var sizeList = _appDbContext.Sizes.Where(a => a.ProductId == data.Id).OrderBy(a=>a.SizeName).ToList();
            //foreach (var colorName in colorsList)
            //{
            //    var color = colorName.Colors.ToString("F");
            //    productDto.ColorsList.Add(color);
            //}
            foreach (var sizeName in sizeList)
            {
                var size = sizeName.SizeName.ToString("F");
                productDto.SizeList.Add(size);
            }
            foreach (var tag in data.Tags)
            {
                var tagDto = new TagDto()
                {

                    Id = tag.Id,
                    Name = tag.Name,
                    
                    CreatedOn = data.CreatedOn,
                    ModifiedOn = data.ModifiedOn,
                    Class = tag.Class

                };
                

                    
                productDto.Tags.Add(tagDto);

            }
            return productDto;
        }
        
    }
}
