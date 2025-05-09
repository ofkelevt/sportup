﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportup.Data;
using sportup.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportup.DTO;
using System.Data;

namespace sportup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToEventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserToEventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserToEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserToEventDto>>> GetUserToEvents()
        {
            return await _context.UserToEvents.Select(u => new UserToEventDto(u)).ToListAsync();
        }

        // GET: api/UserToEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserToEventDto>> GetUserToEvent(int id)
        {
            var userToEvent = await _context.UserToEvents.FindAsync(id);

            if (userToEvent == null)
            {
                return NotFound();
            }

            return new UserToEventDto(userToEvent);
        }

        // PUT: api/UserToEvent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserToEvent(int id, UserToEventDto userToEvent)
        {
            if (id != userToEvent.TableId)
            {
                return BadRequest();
            }

            _context.Entry(userToEvent.ToModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserToEventExists(id))
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

        // POST: api/UserToEvent
        [HttpPost]
        public async Task<ActionResult<UserToEvent>> PostUserToEvent(UserToEventDto userToEvent)
        {
            _context.UserToEvents.Add(userToEvent.ToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserToEvent", new { id = userToEvent.TableId }, userToEvent.ToModel());
        }

        // DELETE: api/UserToEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserToEvent(int id)
        {
            var userToEvent = await _context.UserToEvents.FindAsync(id);
            if (userToEvent == null)
            {
                return NotFound();  
            }

            _context.UserToEvents.Remove(userToEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserToEventExists(int id)
        {
            return _context.UserToEvents.Any(e => e.TableId == id);
        }
    }
}
