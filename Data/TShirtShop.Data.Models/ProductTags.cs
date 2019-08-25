using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Data.Models
{
   public class ProductTags
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
