using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Tag : IAuditInfo
    {
        public string Id { get ; set ; }

        public string Name { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedOn { get; set ; }
        public DateTime? ModifiedOn { get ; set; }
    }
}
