using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
  public  class TagDto : IAuditInfo
    {

        public TagDto()
        {
            Products = new HashSet<ProductDto>();
        }
        public string Id { get; set; }
      
        public string Name { get; set; }

        public ICollection<ProductDto> Products { get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? ModifiedOn { get; set; }
    }
}
