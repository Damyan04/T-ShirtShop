using TShirtShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using TShirtShop.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace TShirtShop.Data.Models
{
    public class Product:IAuditInfo
    {
    
        public Product()
        {
            Tags = new HashSet<ProductTags>();
           
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [Range(0.00,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public Sizes Size { get; set; }
         [Required]
        public Colors Color { get; set; }

        public string PictureId { get; set; }
        public Image Picture { get; set; }
        public ICollection<ProductTags> Tags{get;set;}

        //public string CategoryId { get; set; }
        //public Category Category{ get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
