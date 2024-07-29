using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jayassignment3.Data;
using jayassignment3.Models;

namespace jayassignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly Jayassignment3DbContext _context;

        public CartController(Jayassignment3DbContext context)
        {
            _context = context;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carts = await _context.Carts.ToListAsync();
            return Ok(carts);
        }

        // GET: api/cart/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> CreateCart(CartViewModel cart)
        {
            if (ModelState.IsValid)
            {
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
            }
            return BadRequest(ModelState.Values);
        }


        // DELETE: api/cart/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(m => m.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Cart deleted successfully." });
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
