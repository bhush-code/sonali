using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;


namespace OrderManagement.Repository
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly Order_75827Context _context;

        public OrdersRepo(Order_75827Context context)
        {
            _context = context;
        }

        //to get details of all orders
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        //to get details of particular order by orderid
        public async Task<Orders> GetOrder(int Orderid)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == Orderid);
        }

        //to add order
        public async Task<Orders> AddOrder(Orders orders)
        {
            var result = await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing order
        public async Task<Orders> UpdateOrder(Orders orders)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orders.OrderId);
            if (result != null)
            {
                result.OrderId = orders.OrderId;
                result.UserId = orders.UserId;
                result.OrderNo = orders.OrderNo;
                result.OrderTotal = orders.OrderTotal;
                result.OrderStatus = orders.OrderStatus;
                await _context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing order
        public async Task<Orders> DeleteOrder(int orderid)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderid);
            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}