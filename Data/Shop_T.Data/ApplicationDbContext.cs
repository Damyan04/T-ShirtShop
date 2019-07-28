using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data
{
  public  class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base()
        {

        }

       // public DbSet<TShirt> Tshirts {get;set;}
    }
}
