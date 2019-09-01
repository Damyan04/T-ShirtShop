using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Services;
using TShirtShop.Services.Data;

namespace TShirtShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService __productService;
        public ProductsController(IProductService productService)
        {
            __productService = productService;
        }
        [AllowAnonymous]
      
        public IActionResult Item(string Id)
        {
        var product= __productService.GetProductById(Id);
        
            return View(product);
        }
        //NEED TO Retrieve the picture
        [AllowAnonymous]
     [HttpGet]
        public FileStreamResult ViewImage(ProductDto value)
        {
            string id = value.PictureId;
            return __productService.ViewProduct(id);
        }
        [HttpPost]
        public IActionResult PostComment(string rating, string textAnswer, string Id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            __productService.PostComment(rating, textAnswer, Id, userId);
            return RedirectToAction("Item", new { id=Id});
        }
     

       


    }
}