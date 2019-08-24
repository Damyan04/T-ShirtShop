namespace TShirtShop.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using TShirtShop.Data.Common.Models;

    public class Address:IAuditInfo
    {
       
        public string Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; } //TOOD make it enum
        public string UserId { get; set; }
        public ApplicationUser User{ get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set ; }
    }
}
