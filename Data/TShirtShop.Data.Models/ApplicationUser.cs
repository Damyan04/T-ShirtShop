using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
   public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
        }
        public ICollection<Order> Orders{ get; set; }

        [Range(0.00, double.MaxValue)]
        public double MoneySpent { get; set; } = 0.00;
       
    }
}
