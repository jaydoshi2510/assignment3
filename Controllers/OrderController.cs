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
    public class OrderController : ControllerBase
    {
        private readonly Jayassignment3DbContext _context;

        public OrderController(Jayassignment3DbContext context)
        {
            _context = context;
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        // GET: api/order/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
            }
        
            return BadRequest(ModelState.Values);
        }

        // PUT: api/order/3
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderViewModel order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(order).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
            }
            return BadRequest(ModelState.Values);
        }


        // DELETE: api/order/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Order deleted successfully." });
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
