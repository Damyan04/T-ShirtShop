﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
    public class Category : IBaseModel
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
    }
}