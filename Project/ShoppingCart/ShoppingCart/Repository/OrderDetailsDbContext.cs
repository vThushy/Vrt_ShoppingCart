using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class OrderDetailsDbContext : DbContext
    {
        public OrderDetailsDbContext(DbContextOptions options): base(options)
        {

        }

        //public DbSet<OrderDetail>OrderDetails { get; set; }

        //protected override void OnModelCreating()
        //{

        //}
    }
}
