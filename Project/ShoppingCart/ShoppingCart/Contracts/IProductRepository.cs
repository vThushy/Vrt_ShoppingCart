using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IProductRepository
    {
        public ProductList GetAllProducts(int pageIndex, int take);
        Product GetProduct(int id);
        public ProductList GetProductsByCategory(string searchCategory, int pageIndex, int take);

        //CRUD
        void AddProduct(Product product);
        void ModifyProduct(Product oldProduct, Product newProduct);
        void RemoveProduct(Product product);

    }
}
