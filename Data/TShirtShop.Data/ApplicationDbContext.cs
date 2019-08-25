using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TShirtShop.Data.Models;

namespace TShirtShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductTags> ProductTags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            builder.Entity<ProductTags>()
       .HasKey(bc => new { bc.ProductId, bc.TagId });
            builder.Entity<ProductTags>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.Tags)
                .HasForeignKey(bc => bc.ProductId);
            builder.Entity<ProductTags>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.TagId);
        }

    }
    }

