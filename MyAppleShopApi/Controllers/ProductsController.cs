using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppleShopApi.Models; 


namespace MyAppleShopApi.DAL
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly MyAppDbContext _context;
        public ProductsController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new
            {
                id = product.Id

            },product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var existingProduct = await _context.products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            // Update the product details
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.PriceId = product.PriceId;
            existingProduct.ImageUrl = product.ImageUrl;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); 
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _context.products.Find(id);
                if (product == null)
                {
                    return NotFound($"product with id : {id} not found");
                }
                _context.products.Remove(product);
                _context.SaveChanges();
                return Ok("product deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

