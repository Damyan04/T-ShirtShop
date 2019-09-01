using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Tag : IAuditInfo
    {
      
        [Required]
        [Key]
        public string Id { get ; set ; }
        [Required]
        public string Name { get; set; }

        public string Class { get; set; }
        // public ICollection<ProductTags> Products { get; set; }
        public DateTime CreatedOn { get;private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
