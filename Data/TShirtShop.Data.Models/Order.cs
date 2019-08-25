using Microsoft.AspNetCore.Identity;
using TShirtShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Key]
        public string Id { get ; set ; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; } //range 0-max
        public Product Product{get;set;}
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string ShippingAddress { get; set; }
        [Required]
        public PaymentOptions PaymentOptions { get; set; }
        
        //public string ShoppingCartId { get; set; }
        //public ShoppingCartItem ShoppingCart { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
