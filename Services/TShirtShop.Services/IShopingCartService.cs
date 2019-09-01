using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
  public interface IShopingCartService
    {
        string Id { get; set; }
        IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
        void AddToCart(string productId, int quantity);
       int RemoveFromCart(string productId);
        IEnumerable<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShopingCartTotal();
    }
}
