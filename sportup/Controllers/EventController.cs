using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sportup.Data;
using sportup.Models;
using sportup.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/events/status
        [HttpGet("status")]
        public IActionResult GetServerStatus()
        {
            return Ok("server up and connected");
        }
        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDtos>>> GetEvents()
        {
            return await _context.Events.Select(u => new EventDtos(u)).ToListAsync();
        }
        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDtos>> GetEvent(int id)
        {
            try
            {
                var eventItem = await _context.Events.FindAsync(id);
                if (eventItem == null)
                {
                    return NotFound();
                }

                return new EventDtos(eventItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventDtor eventItem)
        {
            if (id != eventItem.EventId)
            {
                return BadRequest();
            }

            _context.Entry(eventItem.ToModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(EventDtor eventItem)
        {
            _context.Events.Add(eventItem.ToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = eventItem.EventId }, eventItem.ToModel());
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
