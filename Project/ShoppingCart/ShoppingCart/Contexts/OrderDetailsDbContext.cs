using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contexts
{
    public class OrderDetailsDbContext : DbContext
    {
        public OrderDetailsDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<OrderDetail>OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(d => new { d.Id, d.OrderId });
        }
    }
}
