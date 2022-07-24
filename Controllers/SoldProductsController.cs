using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smallStore.Data;
using smallStore.Models;

namespace smallStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoldProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SoldProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoldProduct>>> GetSoldProducts()
        {
          if (_context.SoldProducts == null)
          {
              return NotFound();
          }
            return await _context.SoldProducts.ToListAsync();
        }

        // GET: api/SoldProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoldProduct>> GetSoldProduct(int id)
        {
          if (_context.SoldProducts == null)
          {
              return NotFound();
          }
            var soldProduct = await _context.SoldProducts.FindAsync(id);

            if (soldProduct == null)
            {
                return NotFound();
            }

            return soldProduct;
        }

        // PUT: api/SoldProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoldProduct(int id, SoldProduct soldProduct)
        {
            if (id != soldProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(soldProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoldProductExists(id))
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

        // POST: api/SoldProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoldProduct>> PostSoldProduct(SoldProduct soldProduct)
        {
          if (_context.SoldProducts == null)
          {
              return Problem("Entity set 'AppDbContext.SoldProducts'  is null.");
          }
            _context.SoldProducts.Add(soldProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoldProduct", new { id = soldProduct.Id }, soldProduct);
        }

        // DELETE: api/SoldProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoldProduct(int id)
        {
            if (_context.SoldProducts == null)
            {
                return NotFound();
            }
            var soldProduct = await _context.SoldProducts.FindAsync(id);
            if (soldProduct == null)
            {
                return NotFound();
            }

            _context.SoldProducts.Remove(soldProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoldProductExists(int id)
        {
            return (_context.SoldProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
