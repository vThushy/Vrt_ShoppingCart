using ShoppingCart.Contexts;
using ShoppingCart.Enum;
using ShoppingCart.Models;

namespace ShoppingCartTest.RepositoryTesting
{
    static class SeedData
    {
        public static void SeedAddresses()
        {
            using (var context = new ShoppingCartDbContext(MockDB.GetDbOptions()))
            {
                context.Addresses.Add(new Address { Id = 1, UserName = "Thushy", City = "test1" });
                context.Addresses.Add(new Address { Id = 2, UserName = "Thushy", City = "test2" });
                context.Addresses.Add(new Address { Id = 3, UserName = "Thushy", City = "test3" });
                context.Addresses.Add(new Address { Id = 4, UserName = "Thushy", City = "test4" });
                context.SaveChanges();
            }
        }

        public static void SeedProducts()
        {
            using (var context = new ShoppingCartDbContext(MockDB.GetDbOptions()))
            {
                context.Products.Add(new Product { Id = 1, CategoryId = 1, Name = "Frock", Description = "A-Line frock", BaseProduct = 1, DefaultImage = "1-DEF", Discount = 0, Price = 500, Size = "M", Stock = 5 });
                context.Products.Add(new Product { Id = 2, CategoryId = 2, Name = "Skirt", Description = "A-Line skirt", BaseProduct = 1, DefaultImage = "2-DEF", Discount = 0, Price = 800, Size = "S", Stock = 8 });
                context.Products.Add(new Product { Id = 3, CategoryId = 3, Name = "Jeans", Description = "A-Line frock", BaseProduct = 1, DefaultImage = "3-DEF", Discount = 0, Price = 900, Size = "XS", Stock = 15 });
                context.Products.Add(new Product { Id = 4, CategoryId = 4, Name = "Short", Description = "A-Line frock", BaseProduct = 1, DefaultImage = "4-DEF", Discount = 0, Price = 1500, Size = "XL", Stock = 5 });
                context.Products.Add(new Product { Id = 5, CategoryId = 5, Name = "Shirt", Description = "A-Line frock", BaseProduct = 1, DefaultImage = "5-DEF", Discount = 0, Price = 800, Size = "L", Stock = 12 });
                context.SaveChanges();
            }
        }

        public static void SeedCustomers()
        {
            using (var context = new ShoppingCartDbContext(MockDB.GetDbOptions()))
            {
                context.Customers.Add(new Customer { UserName = "Thushy", FirstName = "Thushy", LastName = "Vimal", /*DateOfBirth = "" ,*/ Gender = Gender.Female, Email = "vthushy@gmail.com" });
                context.Customers.Add(new Customer { UserName = "Thushy1", FirstName = "Thushy1", LastName = "Vimal1", /*DateOfBirth = "" ,*/ Gender = Gender.Female, Email = "vthushy1@gmail.com" });
                context.Customers.Add(new Customer { UserName = "Thushy2", FirstName = "Thushy2", LastName = "Vimal2", /*DateOfBirth = "" ,*/ Gender = Gender.Female, Email = "vthushy2@gmail.com" });
                context.Customers.Add(new Customer { UserName = "Thushy3", FirstName = "Thushy3", LastName = "Vimal3", /*DateOfBirth = "" ,*/ Gender = Gender.Female, Email = "vthushy3@gmail.com" });
                context.Customers.Add(new Customer { UserName = "Thushy4", FirstName = "Thushy4", LastName = "Vimal4", /*DateOfBirth = "" ,*/ Gender = Gender.Female, Email = "vthushy4@gmail.com" });
                context.SaveChanges();
            }
        }

        public static void SeedUsers()
        {
            using (var context = new ShoppingCartDbContext(MockDB.GetDbOptions()))
            {
                context.Users.Add(new User { UserName = "Thushy", Password = "0Thushy", UserRole = AccessRole.Admin, ResetCode = "1"});
                context.Users.Add(new User { UserName = "Thushy1", Password = "1Thushy", UserRole = AccessRole.Admin, ResetCode = "1" });
                context.Users.Add(new User { UserName = "Thushy2", Password = "2Thushy", UserRole = AccessRole.Admin, ResetCode = "1" });
                context.Users.Add(new User { UserName = "Thushy3", Password = "3Thushy", UserRole = AccessRole.Admin, ResetCode = "1" });
                context.Users.Add(new User { UserName = "Thushy4", Password = "4Thushy", UserRole = AccessRole.Admin, ResetCode = "1" });
                context.SaveChanges();
            }
        }
    }
}

