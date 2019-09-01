using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Models.Enums;

namespace TShirtShop.Data.Models
{
   public class Color
    {
        [Key]
      public  string Id { get; set; }
        public Colors Colors { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
