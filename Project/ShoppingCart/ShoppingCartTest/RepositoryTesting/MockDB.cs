using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartTest.RepositoryTesting
{
    static class MockDB
    {
        public static DbContextOptions GetDbOptions()
        {
            var options = new DbContextOptionsBuilder<ShoppingCartDbContext>().UseInMemoryDatabase("shoppingCart").Options;
            return options;
        }
    }
}
