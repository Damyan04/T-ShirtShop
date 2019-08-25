using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class ShoppingCart:IAuditInfo
    {
        public ShoppingCart()
        {
         ShoppingCartItems=   new HashSet<ShoppingCartItem>();
        }
        public string Id { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; } = null;
    }
}
