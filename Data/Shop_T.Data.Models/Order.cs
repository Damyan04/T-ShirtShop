using Shop_T.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
   public class Order:IBaseModel
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
        public User IsUser{ get; set; }
        public string ShippingAddress { get; set; }

        public PaymentOptions PaymentOptions { get; set; }

        public DateTime  IssuedOn{ get; set; }
    }
}
