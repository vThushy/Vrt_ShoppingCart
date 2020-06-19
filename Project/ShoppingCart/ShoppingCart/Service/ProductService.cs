using ShoppingCart.Models;
using ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Service
{
    public class ProductService: IProductRepository
    {
        private readonly ProductDbContext productDbContext;
        public ProductService(ProductDbContext _productDbContext)
        {
            productDbContext = _productDbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productDbContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return productDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
        }

        public void ModifyProduct(Product oldProduct, Product newProduct)
        {
            oldProduct.CategoryId = newProduct.CategoryId;
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.Discount = newProduct.Discount;
            oldProduct.Price = newProduct.Price;
            oldProduct.Image = newProduct.Image;

            productDbContext.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            productDbContext.Remove(product);
            productDbContext.SaveChanges();
        }
    }
}
