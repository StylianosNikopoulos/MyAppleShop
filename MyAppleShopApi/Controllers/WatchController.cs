using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppleShopApi.DAL;
using MyAppleShopApi.Models;


namespace MyAppleShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : Controller
    {
        private readonly MyAppDbContext _context;

        public WatchController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
        {
            return await _context.watches.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Watch>> GetWatch(int id)
        {
            var watch = await _context.watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }

            return watch;
            
        }

        [HttpPost]
        public async Task<ActionResult<Watch>> PostWatch(Watch watch)
        {
            _context.watches.Add(watch);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWatch), new { id = watch.Id }, watch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatch(int id, Watch watch)
        {
            if (id != watch.Id)
            {
                return BadRequest("Watch ID mismatch");
            }

            var existingWatch = await _context.watches.FindAsync(id);
            if (existingWatch == null)
            {
                return NotFound($"Watch with ID {id} not found");
            }

            existingWatch.Name = watch.Name;
            existingWatch.Price = watch.Price;
            existingWatch.PriceId = watch.PriceId;
            existingWatch.ImageUrl = watch.ImageUrl;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(id))
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

        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            try
            {
                var watch = _context.watches.Find(id);
                if (watch == null)
                {
                    return NotFound($"Watch with id: {id} not found");
                }
                _context.watches.Remove(watch);
                _context.SaveChanges();
                return Ok("Watch deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool WatchExists(int id)
        {
            return _context.watches.Any(e => e.Id == id);
        }
    }
}

