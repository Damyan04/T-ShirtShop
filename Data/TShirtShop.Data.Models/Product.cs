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
            Tags = new HashSet<Tag>();
            ColorsList = new HashSet<Color>();
            SizeList = new HashSet<Size>();
            Reviews = new HashSet<Review>();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Range(0.00,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public Sizes Size { get; set; }
         [Required]
        public ICollection<Color> ColorsList { get; set; }
        public ICollection<Size>SizeList { get; set; }
        public string Class { get; set; }
        public string PictureId { get; set; }
        public Image Picture { get; set; }
        public ICollection<Tag> Tags{get;set;}
        public ICollection<Review> Reviews { get; set; }
        //public string CategoryId { get; set; }
        //public Category Category{ get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
