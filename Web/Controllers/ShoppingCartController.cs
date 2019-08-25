using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Services;

namespace TShirtShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShopingCartService _shopingCartService;

        public ShoppingCartController(IShopingCartService shopingCartService)
        {
            _shopingCartService = shopingCartService;
        }
        [AllowAnonymous]
        public IActionResult Cart()
        {
            return View();
        }
    }
}