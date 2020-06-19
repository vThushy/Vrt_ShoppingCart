using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
