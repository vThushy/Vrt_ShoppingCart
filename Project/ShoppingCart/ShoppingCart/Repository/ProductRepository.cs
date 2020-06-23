using ShoppingCart.Contexts;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;
        public ProductRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return shoppingCartDbContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return shoppingCartDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            shoppingCartDbContext.Products.Add(product);
            shoppingCartDbContext.SaveChanges();
        }

        public void ModifyProduct(Product oldProduct, Product newProduct)
        {
            oldProduct.CategoryId = newProduct.CategoryId;
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.Discount = newProduct.Discount;
            oldProduct.Price = newProduct.Price;
            oldProduct.Image = newProduct.Image;

            shoppingCartDbContext.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            shoppingCartDbContext.Remove(product);
            shoppingCartDbContext.SaveChanges();
        }
    }
}
