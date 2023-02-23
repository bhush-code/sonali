using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Repository;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepo _orderRepo;

        public OrdersController(IOrdersRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        // GET: api/Orders/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAllOrders()
        {
            try
            {
                return (await _orderRepo.GetAllOrders()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetAllOrdersById(int id)
        {
            try
            {
                var result = await _orderRepo.GetOrder(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrder(Orders orders)
        {
            try
            {
                if (orders != null)
                {
                    return BadRequest();
                }
                var createOrder = await _orderRepo.AddOrder(orders);
                return CreatedAtAction(nameof(GetAllOrdersById), new { id = createOrder.OrderId }, createOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new order.");
            }

        }

        //PUT: api/Orders
        [HttpPut("{id}")]
        public async Task<ActionResult<Orders>> UpdateOrder(int id, Orders orders)
        {
            try
            {
                if (id != orders.OrderId)
                {
                    return BadRequest("OrderID mismatch....");
                }
                var orderToUpdate = await _orderRepo.GetOrder(id);
                if (orderToUpdate == null)
                {
                    return NotFound("Order with ID {id} not found...");
                }
                return await _orderRepo.UpdateOrder(orders);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<Orders> DeleteOrder(int id)
        {
            try
            {
                var orderToDelete = await _orderRepo.GetOrder(id);
                if (orderToDelete == null)
                {
                    NotFound($"Order with ID {id} found");
                }
                await _orderRepo.DeleteOrder(id);
                return orderToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting order..");
            }
            return null;

        }
    }
}