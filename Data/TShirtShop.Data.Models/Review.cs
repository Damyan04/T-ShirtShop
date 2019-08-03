﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

using System.Text;

namespace Shop_T.Data.Models
{
    public class Review : IBaseModel
    {
        //       - Id(string)
        //- Starts(int)
        //- Comment(string)
        //- User user
        public string Id { get; set ; }
        public int Stars{ get; set; }
        public string Comment{ get; set; }


        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}