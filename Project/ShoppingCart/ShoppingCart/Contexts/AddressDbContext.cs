using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contexts
{
    public class AddressDbContext : DbContext
    {
        public AddressDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set;  }
    }
}
