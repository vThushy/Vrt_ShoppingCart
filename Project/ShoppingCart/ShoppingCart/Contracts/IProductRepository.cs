using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void ModifyProduct(Product oldProduct, Product newProduct);
        void RemoveProduct(Product product);
        Product GetProduct(int id);
        ProductList GetAllProducts(int pageIndex);
        IEnumerable<Product> GetNewArrivalProducts(string category);
        ProductList GetProductsByCategory(string searchCategory, int pageIndex);
        ProductList GetProductsBySearch(string searchKeyword, int pageIndex);
    }
}
