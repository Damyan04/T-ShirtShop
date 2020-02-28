using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Services;

namespace TShirtShop.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductService __productService;
        public AdministratorController(IProductService productService)
        {
            __productService = productService;
        }
        [Authorize(Policy = "AdministratorOnly")]
        public IActionResult UploadProducts()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdministratorOnly")]
        public IActionResult UploadImageWithProduct(ICollection<IFormFile> files,string name,string price, string colors, string tags,string sizes,string className)
        {
            List<string> tagList = tags.Split(";").ToList();
            List<string> colorList = colors.Split(";").ToList();
            List<string> sizeList = sizes.Split(";").ToList();
           
            __productService.AddImage(files,name,price,colorList,tagList, sizeList, className);

            return RedirectToAction("UploadProducts");
        }
    }
}