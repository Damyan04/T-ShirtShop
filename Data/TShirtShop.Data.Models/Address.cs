namespace TShirtShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using TShirtShop.Data.Common.Models;

    public class Address:IAuditInfo
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostCode { get; set; }
       // public string Region { get; set; } //TOOD make it enum
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User{ get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
