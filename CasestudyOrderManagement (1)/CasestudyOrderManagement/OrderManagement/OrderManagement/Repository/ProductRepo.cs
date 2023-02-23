using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly Order_75827Context _context;

        public ProductRepo(Order_75827Context context)
        {
            _context = context;
        }

        //to get details of all products
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        //to get details of particular product by productid
        public async Task<Product> GetProduct(int Productid)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == Productid);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing product
        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _context.Product.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (result != null)
            {
                result.Id = product.Id;
                result.Name = product.Name;
                result.UnitPrice = product.UnitPrice;
                result.DiscountedPrice = product.DiscountedPrice;
                result.Quantity = product.Quantity;
                result.Image = product.Image;
                result.Status = product.Status;
                await _context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing product
        public async Task<Product> DeleteProduct(int productid)
        {
            var result = await _context.Product.FirstOrDefaultAsync(p => p.Id == productid);
            if (result != null)
            {
                _context.Product.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }

}
