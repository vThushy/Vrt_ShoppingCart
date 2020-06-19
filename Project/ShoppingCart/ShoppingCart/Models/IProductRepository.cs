using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void ModifyProduct(Product oldProduct, Product newProduct);
        void RemoveProduct(Product product);

    }
}
