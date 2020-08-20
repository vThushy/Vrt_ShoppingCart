using Microsoft.EntityFrameworkCore.Internal;
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
                foreach (Product p in result)
                {
                    p.Id = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == p.Id).Id;
                }
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

        public ProductWithDetails GetProductWithDetails(int id)

        {
            try
            {


                Product Product = _shoppingCartDbContext.Products.FirstOrDefault(p => p.Id == id);
                // int[] Sizes = _shoppingCartDbContext.ProductDetails.Where(p => p.ProductId )
                //List<ProductDetails> ProductAttr = _shoppingCartDbContext.ProductDetails

                //      .Where(d => d.ProductId == id )
                //      .Select(p => new { p.ProductId, p.Color.Distinct() })
                //      .Distinct()
                //      .ToList();
                // var ProductAttrs = _shoppingCartDbContext.ProductDetails.Where(d => d.ProductId == id).Select(p => p.ProductId).Distinct().ToList();

                List<ProductDetails> ProductAttr = _shoppingCartDbContext.ProductDetails.Where(p => p.ProductId == id).ToList();
                return new ProductWithDetails { Product = Product, ProductDetails = ProductAttr };
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetProductListById(string[] productIds)
        {
            List<ProductDetails> products = _shoppingCartDbContext.ProductDetails.Where(p => productIds.Contains(p.Id.ToString())).ToList();
            List<Product> returnProducts = new List<Product>();

            foreach (ProductDetails p in products)
            {
                Product product = _shoppingCartDbContext.Products.FirstOrDefault(pro => pro.Id == p.ProductId);
                if (product != null)
                {
                    product.Id = p.Id;
                    product.DefaultImage = p.Image;
                }
                returnProducts.Add(product);
            }
            return returnProducts;
        }

        public List<Product> GetNewArrivalProducts(string category)
        {
            try
            {
                if (category == "all")
                {
                    List<Product> products = _shoppingCartDbContext.Products.OrderByDescending(p => p.Id).Take(5).ToList();
                    List<Product> returnProducts = new List<Product>();

                    foreach (Product p in products)
                    {
                        Product addProduct = new Product();
                        addProduct = p;
                        var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                        if (result_ != null)
                        {
                            addProduct.Id = result_.Id;
                            returnProducts.Add(addProduct);
                        }
                    }
                    return returnProducts;
                }
                else
                {
                    int[] categoryId = _shoppingCartDbContext.Categories.Where(c => c.Title.StartsWith(category)).Select(c => c.Id).ToArray();
                    List<Product> products = _shoppingCartDbContext.Products.Where(p => categoryId.Contains(p.CategoryId)).OrderByDescending(p => p.Id).Take(5).ToList();
                    List<Product> returnProducts = new List<Product>();

                    foreach (Product p in products)
                    {
                        Product addProduct = new Product();
                        addProduct = p;
                        var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                        if (result_ != null)
                        {
                            addProduct.Id = result_.Id;
                            returnProducts.Add(addProduct);
                        }
                    }
                    return returnProducts;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetBestSellerProducts(string category)
        {
            try
            {

                if (category == "all")
                {
                    int availableProductsCount = _shoppingCartDbContext.Products.Count() - 5;
                    Random random = new Random();
                    int skip = random.Next(availableProductsCount);
                    List<Product> products = _shoppingCartDbContext.Products.OrderByDescending(p => p.Id).Skip(skip).Take(5).ToList();
                    List<Product> returnProducts = new List<Product>();

                    foreach (Product p in products)
                    {
                        Product addProduct = new Product();
                        addProduct = p;
                        var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                        if (result_ != null)
                        {
                            addProduct.Id = result_.Id;
                            returnProducts.Add(addProduct);
                        }
                    }
                    return returnProducts;
                }
                else
                {
                    int[] categoryId = _shoppingCartDbContext.Categories.Where(c => c.Title.StartsWith(category)).Select(c => c.Id).ToArray();
                    int availableProductsCount = _shoppingCartDbContext.Products.Where(p => categoryId.Contains(p.CategoryId)).Count() - 5;
                    Random random = new Random();
                    int skip = random.Next(availableProductsCount);
                    List<Product> products = _shoppingCartDbContext.Products.Where(p => categoryId.Contains(p.CategoryId))
                        .OrderByDescending(p => p.Id).Skip(skip).Take(5).ToList();
                    List<Product> returnProducts = new List<Product>();

                    foreach (Product p in products)
                    {
                        Product addProduct = new Product();
                        addProduct = p;
                        var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                        if (result_ != null)
                        {
                            addProduct.Id = result_.Id;
                            returnProducts.Add(addProduct);
                        }
                    }
                    return returnProducts;
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

                    List<Product> returnProducts = new List<Product>();

                    foreach (Product p in result)
                    {
                        Product addProduct = new Product();
                        addProduct = p;
                        var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                        if (result_ != null)
                        {
                            addProduct.Id = result_.Id;
                            returnProducts.Add(addProduct);
                        }
                    }

                    return new ProductList
                    {
                        NoOfProducts = noOfRecords,
                        ListOfProducts = returnProducts
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
                    var query = _shoppingCartDbContext.Categories.Where(c => c.Title.Contains(searchCategory)).FirstOrDefault();
                    if (query != null)
                    {
                        int categoryId = query.Id;
                        int noOfRecords = _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).Count();
                        var result = _shoppingCartDbContext.Products.Where(p => p.CategoryId == categoryId).Skip(skip).Take(_productsForPage).ToList();
                        List<Product> returnProducts = new List<Product>();

                        foreach (Product p in result)
                        {
                            Product addProduct = new Product();
                            addProduct = p;
                            var result_ = _shoppingCartDbContext.ProductDetails.FirstOrDefault(pr => pr.ProductId == addProduct.Id);
                            if (result_ != null)
                            {
                                addProduct.Id = result_.Id;
                                returnProducts.Add(addProduct);
                            }
                        }

                        return new ProductList
                        {
                            NoOfProducts = noOfRecords,
                            ListOfProducts = result
                        };
                    }
                    return null;
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
                    product.DefaultImage = newProduct.DefaultImage;

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
