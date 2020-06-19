using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
