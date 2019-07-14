using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop_T.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Designer()
        {
            return View();
        }
    }
}