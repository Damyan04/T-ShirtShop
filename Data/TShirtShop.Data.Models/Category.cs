using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Category : IAuditInfo
    {
     
     
        [Key]
        [Required]
        public string Id { get ; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string TagId { get; set; }
        public Tag Tag { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
    }
}
