using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Review : IAuditInfo
    {
        //       - Id(string)
        //- Starts(int)
        //- Comment(string)
        //- User user
        public string Id { get; set ; }
        public int Stars{ get; set; }
        public string Comment{ get; set; }


        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime CreatedOn { get; set ; }
        public DateTime? ModifiedOn { get ; set ; }
    }
}
