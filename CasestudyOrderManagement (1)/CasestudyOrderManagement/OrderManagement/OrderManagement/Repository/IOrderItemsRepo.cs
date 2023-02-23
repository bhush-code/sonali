using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Repository
{
    public interface IOrderItemsRepo
    {
        Task<IEnumerable<OrderItems>> GetAllOrderitems();
        Task<OrderItems> GetOrderitems(int OrderItemsid);
        Task<OrderItems> AddOrderitems(OrderItems orderItems);
        Task<OrderItems> UpdateOrderitems(OrderItems orderItems);
        Task<OrderItems> DeleteOrderitems(int orderItemsid);
    }
}