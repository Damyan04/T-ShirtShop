using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Review : IAuditInfo
    {
      
        [Required]
        [Key]
        public string Id { get; set ; }
        [Required]
        [Range(0.00, 5.00)]
        public double Stars { get; set; } = 0;
        public string Comment { get; set; } = null;
        [Required]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;

    
    }
}
