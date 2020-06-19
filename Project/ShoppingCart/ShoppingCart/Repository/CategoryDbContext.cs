using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
