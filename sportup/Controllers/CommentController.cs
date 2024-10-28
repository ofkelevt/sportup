using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportup.Data;
using sportup.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportup.DTO;
namespace sportup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            return await _context.Comments.Select(u => new CommentDto(u)).ToListAsync();
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetUserComments(int id)
        {
            return await _context.Comments.Where(u => u.CommenterId == id).Select(u => new CommentDto(u)).ToListAsync();
        }
        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return new CommentDto(comment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentDto comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(comment.ToModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentDto comment)
        {
            _context.Comments.Add(comment.ToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment.ToModel());
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
