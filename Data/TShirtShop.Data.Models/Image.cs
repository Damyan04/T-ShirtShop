using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Image:IAuditInfo
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; } = null;
    }
}
