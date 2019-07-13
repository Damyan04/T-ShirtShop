using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_T.Models;

namespace Shop_T.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Categories()
        {
            var categories = new CategoriesViewModel();
            return View(categories);
        }
    }
}