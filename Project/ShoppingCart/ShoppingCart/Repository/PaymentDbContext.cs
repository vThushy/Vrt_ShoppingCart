using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<Payment> payments { get; set; }
    }
}
