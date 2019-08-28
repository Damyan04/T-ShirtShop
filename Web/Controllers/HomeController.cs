using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Models;
using TShirtShop.Models.TShirts;
using TShirtShop.Services;

namespace TShirtShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService __productService;
        public HomeController(IProductService productService)
        {
            __productService = productService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = __productService.NewestProducts();
            
            return View(products);
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public FileStreamResult ViewProduct(string id)
        {
           return __productService.ViewProduct(id);
        }
    }
}
