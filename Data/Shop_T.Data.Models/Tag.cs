using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
    public class Tag : IBaseModel
    {
        public string Id { get ; set ; }

        public string Name { get; set; }
    }
}
