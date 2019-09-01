using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtShop.Services;

namespace TShirtShop.Models.ShoppingCart
{
    public class ShopingCartViewModel
    {
        public IShopingCartService ShopingCart { get; set; }

        public decimal ShoppingCartTotal { get; set; }
    }
}
