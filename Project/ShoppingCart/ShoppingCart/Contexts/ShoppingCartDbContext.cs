using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contexts
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Stock> Stocks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.Id, p.CategoryId });

            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.Id, o.CustomerId });

            modelBuilder.Entity<OrderDetail>()
                .HasKey(d => new { d.Id, d.OrderId });

            modelBuilder.Entity<Stock>()
                .HasKey(s => new { s.Id, s.ProductId });

            modelBuilder.Entity<Payment>()
                .HasKey(s => new { s.Id, s.OrderId });

            modelBuilder.Entity<User>()
                          .HasData(new User
                          {
                              UserName = "Thushy",
                              Password = "Thushy",
                              UserRole = "Admin"
                          });

        }
    }
}

