using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasKey(s => new { s.Id, s.ProductId });
        }
    }
}
