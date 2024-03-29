﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Contexts
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion<int>();

            modelBuilder.Entity<Customer>()
                .Property(u => u.Gender)
                .HasConversion<int>();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .Property(u => u.OrderStatus)
                .HasConversion<int>();

            modelBuilder.Entity<Payment>()
                .Property(u => u.PayMethod)
                .HasConversion<int>();

            modelBuilder.Entity<ProductDetails>()
                .Property(u => u.Size)
                .HasConversion<int>();

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserName = "Thushy",
                    Password = "4d7cc50ef7ead5edb9903a94eeb0fb4381b82a89ea6872bf28ae287ae751ae8c",
                    UserRole = Enum.AccessRole.Admin,
                    ResetCode = "1"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}

