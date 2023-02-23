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
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsRepo _orderitemsRepo;

        public OrderItemsController(IOrderItemsRepo orderitemsRepo)
        {
            _orderitemsRepo = orderitemsRepo;
        }

        // GET: api/OrderItems/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetAllOrderitems()
        {
            try
            {
                return (await _orderitemsRepo.GetAllOrderitems()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> GetAllOrderitemsById(int id)
        {
            try
            {
                var result = await _orderitemsRepo.GetOrderitems(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItems>> CreateOrderItems(OrderItems orderItems)
        {
            try
            {
                if (orderItems != null)
                {
                    return BadRequest();
                }
                var createOrderitems = await _orderitemsRepo.AddOrderitems(orderItems);
                return CreatedAtAction(nameof(GetAllOrderitemsById), new { id = createOrderitems.OrderId }, createOrderitems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new orderitems.");
            }

        }

        //PUT: api/OrderItems
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItems>> UpdateOrderitems(int id, OrderItems orderItems)
        {
            try
            {
                if (id != orderItems.Id)
                {
                    return BadRequest("OrderItems ID mismatch....");
                }
                var orderitemsToUpdate = await _orderitemsRepo.GetOrderitems(id);
                if (orderitemsToUpdate == null)
                {
                    return NotFound("Orderitems with ID {id} not found...");
                }
                return await _orderitemsRepo.UpdateOrderitems(orderItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<OrderItems> DeleteOrderitems(int id)
        {
            try
            {
                var orderitemsToDelete = await _orderitemsRepo.GetOrderitems(id);
                if (orderitemsToDelete == null)
                {
                    NotFound($"Orderitem with ID {id} found");
                }
                await _orderitemsRepo.DeleteOrderitems(id);
                return orderitemsToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting orderitems..");
            }
            return null;

        }
    }
}