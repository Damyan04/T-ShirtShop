using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
  public  class TagDto : IAuditInfo
    {

   
        public string Id { get; set; }
      
        public string Name { get; set; }

        public string Class { get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? ModifiedOn { get; set; }
    }
}
