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

        public ProductList GetAllProducts(int pageIndex, int take)
        {
            try
            {
                int skip = (pageIndex - 1) * take;
                int noOfRecords = shoppingCartDbContext.Products.Where(p => p.CategoryId == 5).Count();
                var result = shoppingCartDbContext.Products.Skip(skip).Take(take).ToList();
                return new ProductList
                {
                    NoOfProducts = noOfRecords,
                    ListOfProducts = result
                };
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

        public ProductList GetProductsByCategory(string searchCategory, int pageIndex, int take)
        {
            try
            {
                int skip = (pageIndex - 1) * take;
                int noOfRecords = shoppingCartDbContext.Products.Where(p => p.CategoryId == 5).Count();
                var result = shoppingCartDbContext.Products.Where(p => p.CategoryId == 5).Skip(skip).Take(take).ToList();
                return new ProductList
                {
                    NoOfProducts = noOfRecords,
                    ListOfProducts = result
                };
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
