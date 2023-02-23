using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int Productid);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productid);
    }
}