using Microsoft.Data.SqlClient;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        private int _productsForPage;
        #endregion

        #region constructor
        public ProductRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
            _productsForPage = Constants.productsForPage;
        }
        #endregion

        #region methods
        public ProductList GetAllProducts(int pageIndex)
        {
            try
            {
                int skip = (pageIndex - 1) * _productsForPage;
                int noOfRecords = _shoppingCartDbContext.Products.Count();
                var result = _shoppingCartDbContext.Products.Skip(skip).Take(_productsForPage).ToList();
                return new ProductList
                {
                    NoOfProducts = noOfRecords,
                    ListOfProducts = result
                };
            }
            catch
            {
                throw;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                return _shoppingCartDbContext.Products.FirstOrDefault(p => p.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Product> GetNewArrivalProducts(string category)
        {
            try
            {
                if(category == "all")
                {
                    return _shoppingCartDbContext.Products.OrderByDescending(p => p.Id).Take(5).ToList();
                }
                else
                {
                    int categoryId = _shoppingCartDbContext.Categories.Where(c => c.Title.Contains(category)).FirstOrDefault().Id;
                    return _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).OrderByDescending(p => p.Id).Take(5).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public ProductList GetProductsBySearch(string searchCategory, int pageIndex)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchCategory))
                {
                    int skip = (pageIndex - 1) * _productsForPage;

                    int[] categoryIds = _shoppingCartDbContext.Categories.Where(c => c.Title.Contains(searchCategory) || c.Description.Contains(searchCategory)
                    || c.Keyword.Contains(searchCategory)).Select(c => c.Id).ToArray();

                    int noOfRecords = _shoppingCartDbContext.Products.Where(p => p.Name.Contains(searchCategory) || p.Description.Contains(searchCategory))
                        .Union(_shoppingCartDbContext.Products.Where(p => categoryIds.Contains(p.CategoryId))).Count();


                    List<Product> result = _shoppingCartDbContext.Products.Where(p => p.Name.Contains(searchCategory) || p.Description.Contains(searchCategory))
                        .Union(_shoppingCartDbContext.Products.Where(p => categoryIds.Contains(p.CategoryId))).Skip(skip).Take(_productsForPage).ToList();

                    return new ProductList
                    {
                        NoOfProducts = noOfRecords,
                        ListOfProducts = result
                    };
                }
                else
                {
                    throw new Exception("search category or pageindex is empty!");
                }
              
            }
            catch
            {
                throw;
            }
        }



        public ProductList GetProductsByCategory(string searchCategory, int pageIndex)
        {
            try
            {
                int skip = (pageIndex - 1) * _productsForPage;
                int noOfRecords = _shoppingCartDbContext.Products.Where(p => p.CategoryId == 5).Count();
                var result = _shoppingCartDbContext.Products.Where(p => p.CategoryId == 5).Skip(skip).Take(_productsForPage).ToList();
                return new ProductList
                {
                    NoOfProducts = noOfRecords,
                    ListOfProducts = result
                };
            }
            catch
            {
                throw;
            }
        }




        public void AddProduct(Product product)
        {
            try
            {
                _shoppingCartDbContext.Products.Add(product);
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ModifyProduct(Product oldProduct, Product newProduct)
        {
            try
            {
                if (oldProduct != null && newProduct != null)
                {
                    oldProduct.CategoryId = newProduct.CategoryId;
                    oldProduct.Name = newProduct.Name;
                    oldProduct.Description = newProduct.Description;
                    oldProduct.Discount = newProduct.Discount;
                    oldProduct.Price = newProduct.Price;
                    oldProduct.Image = newProduct.Image;

                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                _shoppingCartDbContext.Remove(product);
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
