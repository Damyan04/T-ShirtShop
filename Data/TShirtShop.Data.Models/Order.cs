using Microsoft.AspNetCore.Identity;
using TShirtShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
   public class Order:IAuditInfo
    {
        //       - Id(string)
        //- IssuedOn(dateTime)
        //- Quantity(int)
        //- Product(Product)
        //- Isuser(User)
        //- Shipping address(string)
        //- Payment option(enum)
        
        public string Id { get ; set ; }
        public int Quantity { get; set; } //range 0-max
        public Product Product{get;set;}
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string ShippingAddress { get; set; }

        public PaymentOptions PaymentOptions { get; set; }

        public DateTime  IssuedOn{ get; set; }

        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
    }
}
