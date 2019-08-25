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
        IAuditInfo GetCart(IServiceProvider services);
        void AddToCart(string productId, int quantity, string cartId);
       int RemoveFromCart(string productId, string cartId);
       IEnumerable<IAuditInfo> GetShoppingCartItems(string cartId);
        void ClearCart(string cartId);
        decimal GetShopingCartTotal(string cartId);
    }
}
