using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Models.ShoppingCart;
using TShirtShop.Services;
using TShirtShop.Services.Data;

namespace TShirtShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShopingCartService _shopingCartService;
        private readonly IProductService _productService;
        public ShoppingCartController(IShopingCartService shopingCartService, IProductService productService)
        {
            _shopingCartService = shopingCartService;
            _productService=productService;
        }
        [AllowAnonymous]
        public IActionResult Cart()
        {
            var items = _shopingCartService.GetShoppingCartItems();
            _shopingCartService.ShoppingCartItems = items;

            var sCVM = new ShopingCartViewModel()
            {
                ShopingCart = _shopingCartService,
                ShoppingCartTotal = _shopingCartService.GetShopingCartTotal()


            };
            return View(sCVM);
        }
        [AllowAnonymous]
        public IActionResult AddToShoppingCart(ProductDto product)
        {
           
                _shopingCartService.AddToCart(product.Id, 1);
            return RedirectToAction("Cart");
        }
        [AllowAnonymous]
        public IActionResult RemoveFromShoppingCart(string Id)
        {

            _shopingCartService.RemoveFromCart(Id);
            return RedirectToAction("Cart");
        }
        [AllowAnonymous]
        public IActionResult CheckOut(string Id)
        {

            return View();
        }
    }
}