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
    public class CommentController : ControllerBase
    {
        private readonly Jayassignment3DbContext _context;

        public CommentController(Jayassignment3DbContext context)
        {
            _context = context;
        }

        // GET: api/comment
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return Ok(comments);
        }

        // GET: api/comment/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // DELETE: api/comment
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
            }
        
            return BadRequest(ModelState.Values);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
