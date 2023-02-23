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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/Product/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                return (await _productRepo.GetAllProducts()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAllProductsById(int id)
        {
            try
            {
                var result = await _productRepo.GetProduct(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    return BadRequest();
                }
                var createProduct = await _productRepo.AddProduct(product);
                return CreatedAtAction(nameof(GetAllProductsById), new { id = createProduct.Id }, createProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new product..");
            }

        }

        //PUT: api/Product
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest("ProductID mismatch....");
                }
                var productToUpdate = await _productRepo.GetProduct(id);
                if (productToUpdate == null)
                {
                    return NotFound("product with ID {id} not found...");
                }
                return await _productRepo.UpdateProduct(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await _productRepo.GetProduct(id);
                if (productToDelete == null)
                {
                    NotFound($"Product with ID {id} found");
                }
                await _productRepo.DeleteProduct(id);
                return productToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting product..");
            }
            return null;

        }
    }
}