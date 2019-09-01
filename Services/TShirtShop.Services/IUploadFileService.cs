using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Services.Data;
namespace TShirtShop.Services
{
   public  interface IUploadFileService
    {
       void AddImageForUser(IList<IFormFile> files,string userId);
       List<string> GetAllUserImg(string userId);

        FileStreamResult ViewImage(string imageId);
        ICollection<string> GetAllSizes();
    }
}
