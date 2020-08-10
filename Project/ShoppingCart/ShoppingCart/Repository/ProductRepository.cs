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

        public List<Product> GetNewArrivalProducts(string category)
        {
            try
            {
                if (category == "all")
                {
                    return _shoppingCartDbContext.Products.OrderByDescending(p => p.Id).Take(5).ToList();
                }
                else
                {
                    int categoryId = _shoppingCartDbContext.Categories.Where(c => c.Title.StartsWith(category)).FirstOrDefault().Id;
                    return _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).OrderByDescending(p => p.Id).Take(5).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public ProductList GetProductsBySearch(string searchKey, int pageIndex)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchKey))
                {
                    int skip = (pageIndex - 1) * _productsForPage;

                    int[] categoryIds = _shoppingCartDbContext.Categories.Where(c => c.Title.Contains(searchKey) || c.Description.Contains(searchKey)
                    || c.Keyword.Contains(searchKey)).Select(c => c.Id).ToArray();

                    int noOfRecords = _shoppingCartDbContext.Products.Where(p => p.Name.Contains(searchKey) || p.Description.Contains(searchKey))
                        .Union(_shoppingCartDbContext.Products.Where(p => categoryIds.Contains(p.CategoryId))).Count();


                    List<Product> result = _shoppingCartDbContext.Products.Where(p => p.Name.Contains(searchKey) || p.Description.Contains(searchKey))
                        .Union(_shoppingCartDbContext.Products.Where(p => categoryIds.Contains(p.CategoryId))).Skip(skip).Take(_productsForPage).ToList();

                    return new ProductList
                    {
                        NoOfProducts = noOfRecords,
                        ListOfProducts = result
                    };
                }
                return null;
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
                if (searchCategory != null)
                {
                    int skip = (pageIndex - 1) * _productsForPage;
                    int categoryId = _shoppingCartDbContext.Categories.Where(c => c.Title.Contains(searchCategory)).FirstOrDefault().Id;
                    int noOfRecords = _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).Count();
                    var result = _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).Skip(skip).Take(_productsForPage).ToList();
                    return new ProductList
                    {
                        NoOfProducts = noOfRecords,
                        ListOfProducts = result
                    };
                }
                return null;
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
                if (product != null)
                {
                    _shoppingCartDbContext.Products.Add(product);
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void ModifyProduct(int productId, Product newProduct)
        {
            try
            {
                if (productId > 0 && newProduct != null)
                {
                    Product product = _shoppingCartDbContext.Products.Where(p => p.Id == productId).FirstOrDefault();
                    product.CategoryId = newProduct.CategoryId;
                    product.Name = newProduct.Name;
                    product.Description = newProduct.Description;
                    product.Discount = newProduct.Discount;
                    product.Price = newProduct.Price;
                    product.Image = newProduct.Image;

                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void RemoveProduct(int productId)
        {
            try
            {
                if (productId > 0)
                {
                    Product product = _shoppingCartDbContext.Products.Where(p => p.Id == productId).FirstOrDefault();
                    _shoppingCartDbContext.Products.Remove(product);
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
