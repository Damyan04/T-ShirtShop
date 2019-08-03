using Shop_T.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Shop_T.Data.Models
{
    public class Product:IBaseModel
    {
        //      - Id (string)
        //- Name (string)
        //- List of Tags (List)
        //- Price (decimal)
        //- List of Reviews (List)
        //- Sizes (enum)
        //- Colours (enum)
        //- Design picture (string)
        public Product()
        {
            Tags = new HashSet<Tag>();
        }
        public string Id { get; set; }
        public decimal Price { get; set; }

        public Sizes Size { get; set; }
        public Colors Color { get; set; }
        public byte[] Picture { get; set; }
        public IEnumerable<Tag> Tags{get;set;}

        public string CategoryId { get; set; }
        public Category Category{ get; set; }

    }
}
