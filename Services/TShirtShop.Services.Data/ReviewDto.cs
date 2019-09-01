using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Services.Data
{
  public class ReviewDto
    {
        
        public string Id { get; set; }
       
       
        public double Stars { get; set; } 
        public string Comment { get; set; } 
      
        public string ProductId { get; set; }
        public string UserName{ get; set; }
        public string UserId { get; set; }        
        public DateTime CreatedOn { get;  set; } 
        public DateTime? ModifiedOn { get; set; } 


    }
}
