using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Data.Common.Models;

namespace TShirtShop.Data.Models
{
    public class Category : IAuditInfo
    {
        //      - Id(string)
        //- Name(string)
        //- List of Products(List)
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Id { get ; set; }
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get ; set ; }
    }
}
