using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class ShoppingCartItem : IAuditInfo
    {
        //      List of Products(List)
        //- Quantity(int)
        //- Isuser(User) NEED Research

        [Key]
        public string ItemId { get; set; }

       
        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; } = null;
    }
}
