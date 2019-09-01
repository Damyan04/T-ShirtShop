using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Models.Enums;

namespace TShirtShop.Data.Models
{
   public class Size
    {
        [Key]
        public string Id { get; set; }
        public Sizes SizeName { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
