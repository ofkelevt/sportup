using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportup.Data;
using sportup.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatComment>>> GetChatComments()
        {
            return await _context.ChatComments.ToListAsync();
        }

        // GET: api/ChatComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatComment>> GetChatComment(int id)
        {
            var chatComment = await _context.ChatComments.FindAsync(id);

            if (chatComment == null)
            {
                return NotFound();
            }

            return chatComment;
        }

        // PUT: api/ChatComment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatComment(int id, ChatComment chatComment)
        {
            if (id != chatComment.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(chatComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatCommentExists(id))
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

        // POST: api/ChatComment
        [HttpPost]
        public async Task<ActionResult<ChatComment>> PostChatComment(ChatComment chatComment)
        {
            _context.ChatComments.Add(chatComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatComment", new { id = chatComment.CommentId }, chatComment);
        }

        // DELETE: api/ChatComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatComment(int id)
        {
            var chatComment = await _context.ChatComments.FindAsync(id);
            if (chatComment == null)
            {
                return NotFound();
            }

            _context.ChatComments.Remove(chatComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatCommentExists(int id)
        {
            return _context.ChatComments.Any(e => e.CommentId == id);
        }
    }
}
