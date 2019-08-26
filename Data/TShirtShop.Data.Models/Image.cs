using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Data.Models
{
    public class Image
    {
        public Image()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }
       

    }
}
