using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShirtShop.Data;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models;
using TShirtShop.Services.Data;

namespace TShirtShop.Services
{
    public class ShopingCartService:IShopingCartService
    {
        private readonly ApplicationDbContext _appDbContext;
        public string Id { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShopingCartService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public static ShopingCartService GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetRequiredService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShopingCartService(context)
            {
                Id= cartId
            };
            //TODO in the Controller to make a viewmodel
        }
      
        public void AddToCart(string productId,int quantity)
        {
           
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
s=>s.ProductId==productId&&s.ShoppingCartId==Id
                );
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ShoppingCartId = Id,
                    Product = GetProductById(productId),
                    Quantity = 1,
                    ProductId=productId
                    

                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _appDbContext.SaveChanges();
        }
        public int RemoveFromCart(string productId)
        {
           
            var product = GetProductById(productId);
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
s => s.ProductId == product.Id && s.ShoppingCartId == Id);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _appDbContext.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }
        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
          
            IEnumerable<ShoppingCartItem> data= _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == Id).Include(w => w.Product).ToList();
            return data;
            //TODO:return DTO;
        }
        public void ClearCart()
        {
          
            var cartItems = _appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == Id);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }
        public decimal GetShopingCartTotal()
        {
           
            decimal total = (decimal)_appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                .Select(c=>c.Product.Price*c.Quantity).Sum();
            return total;
        }
        private Product GetProductById(string productId)
        {
            return _appDbContext.Products.FirstOrDefault(s => s.Id == productId);
        }
       private ShoppingCart GetShoppingCartById(string cartId)
        {
           var cart= _appDbContext.ShoppingCarts.SingleOrDefault(w => w.Id == cartId);
            return cart;
        }
    }
}
