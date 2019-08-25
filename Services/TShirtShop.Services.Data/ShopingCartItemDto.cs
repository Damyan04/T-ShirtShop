using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
    public class ShopingCartItemDto : IAuditInfo
    {
        public string ItemId { get; set; }
        public string ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string ProductId { get; set; }

        public ProductDto Product { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;


        public DateTime? ModifiedOn { get; set; } 
    }
}
