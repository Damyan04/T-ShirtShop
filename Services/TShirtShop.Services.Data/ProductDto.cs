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
        public string Name { get; set; }
       
        public double Price { get; set; }
      
        public Sizes Size { get; set; }
        public string Class { get; set; }
        public ICollection<string> ColorsList { get; set; }
        public ICollection<string> SizeList { get; set; }
        public string PictureId { get; set; }
        public ImageDto Picture { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }

        //public string CategoryId { get; set; }
        //public Category Category{ get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? ModifiedOn { get; set; }
    }

  
}
