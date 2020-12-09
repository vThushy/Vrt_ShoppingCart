using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IProductRepository
    {
        #region contracts
        ProductList GetAllProducts(int pageIndex);
        Product GetProduct(int id);
        List<Product> GetProductWithDetails(int id);
        List<Product> GetNewArrivalProducts(string category);
        List<Product> GetBestSellerProducts(string category);
        ProductList GetProductsBySearch(string searchKey, int pageIndex);
        ProductList GetProductsByCategory(string searchCategory, int pageIndex);
        List<Product> GetSimilarProducts(int categoryId);
        Product AddProduct(Product product);
        Product ModifyProduct(int productId, Product newProduct);
        Boolean RemoveProduct(int productId);
        Boolean ReduceStock(List<OrderDetail> lines);
        #endregion
    }
}
