using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;
using TShirtShop.Data.Models.Enums;

namespace TShirtShop.Services.Data
{
    public class ProductDto : IAuditInfo
    {
     
        public string Id { get; set; }
        [Required]
        [Range(0.00, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public Sizes Size { get; set; }
        [Required]
        public Colors Color { get; set; }
        public string PictureId { get; set; }
        public ImageDto Picture { get; set; }
        public ICollection<TagDto> Tags { get; set; }

        //public string CategoryId { get; set; }
        //public Category Category{ get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? ModifiedOn { get; set; }
    }

  
}
