using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsByCategory(string searchCategory);

        //CRUD
        void AddProduct(Product product);
        void ModifyProduct(Product oldProduct, Product newProduct);
        void RemoveProduct(Product product);

    }
}
