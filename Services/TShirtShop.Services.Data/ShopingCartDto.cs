using System;
using System.Collections.Generic;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
    public class ShopingCartDto : IAuditInfo
    {
        public string ShopingCartId { get; set; }
      
      
        public ICollection<ShopingCartItemDto> ShoppingCartItems { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
