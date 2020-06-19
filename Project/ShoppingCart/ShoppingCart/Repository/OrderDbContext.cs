using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => new { o.Id, o.CustomerId });
        }
    }
}
