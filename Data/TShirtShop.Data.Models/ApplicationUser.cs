using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Data.Models
{
   public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
        }
        public IEnumerable<Order> Orders{ get; set; }

        public decimal MoneySpent{ get; set; }
    
    }
}
