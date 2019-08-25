using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_T.Models;

namespace Shop_T.Controllers
{
    public class ProductCategoriesController : Controller
    {
        [AllowAnonymous]
        public IActionResult TShirts()
        {
            var categories = new CategoriesViewModel();
            return View(categories);
        }
    }
}