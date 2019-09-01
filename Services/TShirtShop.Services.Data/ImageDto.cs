using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Services.Data
{
  public  class ImageDto:IAuditInfo
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; } 
    }
}
