using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetReports()
        {
            return await _context.Reports.Select(u => new ReportDto(u)).ToListAsync();
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return new ReportDto(report);
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetUserReports(int id)
        {
            return await _context.Reports.Where(u => u.TargetId == id).Select(u => new ReportDto(u)).ToListAsync();
        }
        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, ReportDto report)
        {
            if (id != report.ReporterId)
            {
                return BadRequest();
            }

            _context.Entry(report.ToModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
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

        // POST: api/Reports
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(ReportDto report)
        {
            _context.Reports.Add(report.ToModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReport", new { id = report.ReporterId }, report.ToModel());
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.ReporterId == id);
        }
    }
}
