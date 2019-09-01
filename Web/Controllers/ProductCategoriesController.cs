using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Services;

namespace TShirtShop.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly IProductService __productService;
        public ProductCategoriesController(IProductService productService)
        {
            __productService = productService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult TShirts()
        {
            ViewData["ProductDto"] = __productService.Products();
            ViewData["TagDto"] = __productService.GetTags();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public FileStreamResult ViewProductCategory(string id)
        {
            return __productService.ViewProduct(id);
        }
    }
}