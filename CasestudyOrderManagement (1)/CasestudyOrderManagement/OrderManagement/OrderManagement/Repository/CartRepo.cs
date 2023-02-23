using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly Order_75827Context _context;

        public CartRepo(Order_75827Context context)
        {
            _context = context;
        }

        //to get details of all cart
        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _context.Cart.ToListAsync();
        }

        //to get details of particular cartitem by id
        public async Task<Cart> GetCart(int Cartid)
        {
            return await _context.Cart.FirstOrDefaultAsync(c => c.Id == Cartid);
        }

        //to add cartitems
        public async Task<Cart> AddCart(Cart cart)
        {
            var result = await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing cart
        public async Task<Cart> UpdateCart(Cart cart)
        {
            var result = await _context.Cart.FirstOrDefaultAsync(c => c.Id == cart.Id);
            if (result != null)
            {
                result.Id = cart.Id;
                result.UserId = cart.UserId;
                result.ProductId = cart.ProductId;
                result.UnitPrice = cart.UnitPrice;
                result.DiscountedPrice = cart.DiscountedPrice;
                result.Quantity = cart.Quantity;
                result.TotalPrice = cart.TotalPrice;

                await _context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing cart
        public async Task<Cart> DeleteCart(int cartid)
        {
            var result = await _context.Cart.FirstOrDefaultAsync(c => c.Id == cartid);
            if (result != null)
            {
                _context.Cart.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}