using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.Id, p.CategoryId });
        }
    }
}

