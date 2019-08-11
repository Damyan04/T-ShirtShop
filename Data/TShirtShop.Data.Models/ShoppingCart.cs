using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Data.Models
{
   public class ShoppingCart
    {
        //      List of Products(List)
        //- Quantity(int)
        //- Isuser(User) NEED Research
        public ShoppingCart()
        {
            Orders = new HashSet<Order>();
        }
        public string Id { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        //public User IsUser { get; set; }
    }
}
