using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
  public class Address
    {
       
        public string Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; } //TOOD make it enum
        public string UserId { get; set; }
        public IdentityUser User{ get; set; }
    }
}
