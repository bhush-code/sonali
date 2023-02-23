using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;


namespace OrderManagement.Repository
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        private readonly Order_75827Context _context;

        public OrderItemsRepo(Order_75827Context context)
        {
            _context = context;
        }

        //to get details of all orders
        public async Task<IEnumerable<OrderItems>> GetAllOrderitems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        //to get details of particular orderitem by orderitemsid
        public async Task<OrderItems> GetOrderitems(int OrderItemsid)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == OrderItemsid);
        }

        //to add orderitems
        public async Task<OrderItems> AddOrderitems(OrderItems orderItems)
        {
            var result = await _context.OrderItems.AddAsync(orderItems);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing orderitems
        public async Task<OrderItems> UpdateOrderitems(OrderItems orderItems)
        {
            var result = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItems.Id);
            if (result != null)
            {
                result.Id = orderItems.Id;
                result.OrderId = orderItems.OrderId;
                result.ProductId = orderItems.ProductId;
                result.UnitPrice = orderItems.UnitPrice;
                result.DiscountedPrice = orderItems.DiscountedPrice;
                result.Quantity = orderItems.Quantity;
                result.TotalPrice = orderItems.TotalPrice;

                await _context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing orderitems
        public async Task<OrderItems> DeleteOrderitems(int orderItemsid)
        {
            var result = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItemsid);
            if (result != null)
            {
                _context.OrderItems.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}