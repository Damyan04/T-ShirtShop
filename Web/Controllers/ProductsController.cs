using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Models.TShirts;
using TShirtShop.Services;

namespace TShirtShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUploadFileService __uploadFileService;
        public ProductsController(IUploadFileService uploadFileService)
        {
            __uploadFileService = uploadFileService;

        }
        public IActionResult Designer()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var imgIds = __uploadFileService.GetAllUserImg(userId);
           
            return View(imgIds);
        }
        [AllowAnonymous]
       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImage(IList<IFormFile> files)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            __uploadFileService.AddImageForUser(files, userId);
            
            return RedirectToAction("Designer");
        }
        //TODO:resize pictures
        [HttpGet]
        public FileStreamResult ViewImage(string id)
        {
          return  __uploadFileService.ViewImage(id);
        }
   





    }
}
