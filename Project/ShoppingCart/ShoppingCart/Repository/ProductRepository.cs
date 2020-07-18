using Microsoft.Win32.SafeHandles;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
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
            try
            {
                return shoppingCartDbContext.Products.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                return shoppingCartDbContext.Products.FirstOrDefault(p => p.Id == id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string searchCategory)
        {
            //var query1 = from category in shoppingCartDbContext.Categories
            //             join product in shoppingCartDbContext.Products on category.Id equals product.CategoryId into Product
            //             from m in Details.DefaultIfEmpty()
            //             select new
            //             {
            //                 product
            //             };
            //return query1.ToList<Product>();

            //var query = from category in shoppingCartDbContext.Set<Category>()
            //            join product in shoppingCartDbContext.Set<Product>()
            //                on category.Id equals product.CategoryId
            //            where category.Title.Contains("WOMEN")
            //            select new { product };
            //return
            try
            {
                var result = shoppingCartDbContext.Products.Where(p => p.CategoryId == 5);
                return result.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void AddProduct(Product product)
        {
            try
            {
                shoppingCartDbContext.Products.Add(product);
                shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void ModifyProduct(Product oldProduct, Product newProduct)
        {
            try
            {
                oldProduct.CategoryId = newProduct.CategoryId;
                oldProduct.Name = newProduct.Name;
                oldProduct.Description = newProduct.Description;
                oldProduct.Discount = newProduct.Discount;
                oldProduct.Price = newProduct.Price;
                oldProduct.Image = newProduct.Image;

                shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                shoppingCartDbContext.Remove(product);
                shoppingCartDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
