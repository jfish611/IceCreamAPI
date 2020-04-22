using IceCreamAPI.Models;
using System.Collections.Generic;

namespace IceCreamAPI.Services
{
    public interface IDAL
    {
        int CreateProduct(Product p);
        int DeleteProductById(int id);
        Product GetProductById(int id);
        string[] GetProductCategories();
        IEnumerable<Product> GetProductsAll();
        IEnumerable<Product> GetProductsByCategory(string category);
        //int UpdateProductById(Product prod);
    }
   
}