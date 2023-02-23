using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Repository
{
    public interface ICartRepo
    {
        Task<IEnumerable<Cart>> GetAllCart();
        Task<Cart> GetCart(int Cartid);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int cartid);
    }
}