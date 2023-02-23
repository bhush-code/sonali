using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using OrderManagement.Repository;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepo;

        public CartController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        // GET: api/Cart/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCart()
        {
            try
            {
                return (await _cartRepo.GetAllCart()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetAllCartById(int id)
        {
            try
            {
                var result = await _cartRepo.GetCart(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart(Cart cart)
        {
            try
            {
                if (cart != null)
                {
                    return BadRequest();
                }
                var createCart = await _cartRepo.AddCart(cart);
                return CreatedAtAction(nameof(GetAllCartById), new { id = createCart.Id }, createCart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new orderitems.");
            }

        }

        //PUT: api/Cart
        [HttpPut("{id}")]
        public async Task<ActionResult<Cart>> UpdateCart(int id, Cart cart)
        {
            try
            {
                if (id != cart.Id)
                {
                    return BadRequest("Cart ID mismatch....");
                }
                var cartToUpdate = await _cartRepo.GetCart(id);
                if (cartToUpdate == null)
                {
                    return NotFound("cart items with ID {id} not found...");
                }
                return await _cartRepo.UpdateCart(cart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<Cart> DeleteCart(int id)
        {
            try
            {
                var cartToDelete = await _cartRepo.GetCart(id);
                if (cartToDelete == null)
                {
                    NotFound($"....cart item with ID {id} found....");
                }
                await _cartRepo.DeleteCart(id);
                return cartToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting cart items..");
            }
            return null;

        }
    }
}