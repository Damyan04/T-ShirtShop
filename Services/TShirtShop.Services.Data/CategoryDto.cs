using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
  public  class CategoryDto:IAuditInfo
    {
        public string Id { get; set; }
       
        public string Name { get; set; }

        //public IEnumerable<Product> Products { get; set; }
        
        public string TagId { get; set; }
        public TagDto Tag { get; set; }
        public DateTime CreatedOn { get;  set; } 
        public DateTime? ModifiedOn { get; set; } 
    }
}
