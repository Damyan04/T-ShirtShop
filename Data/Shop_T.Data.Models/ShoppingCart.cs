using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
   public class ShoppingCart
    {
        //      List of Products(List)
        //- Quantity(int)
        //- Isuser(User) NEED Research
        public IEnumerable<Order> Orders { get; set; }
        public User IsUser { get; set; }
    }
}
