using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly NwutechTrendsContext _context;

        public TelemetryController(NwutechTrendsContext context)
        {
            _context = context;
        }

        // GET: api/JobTelemetry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetries.ToListAsync();
        }

        // GET: api/JobTelemetry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // POST: api/JobTelemetry
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTelemetry", new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // PATCH: api/JobTelemetry/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTelemetry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // DELETE: api/JobTelemetry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Private method to check if JobTelemetry exists
        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        // GET: api/JobTelemetry/GetSavingsByDateRange
        [HttpGet("GetSavingsByDateRange")]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetSavingsByDateRange(DateTime startDate, DateTime endDate)
        {
            var jobTelemetry = await _context.JobTelemetries
                .Where(t => t.EntryDate >= startDate && t.EntryDate <= endDate)
                .ToListAsync();
            // Calculate time and cost savings here
            return jobTelemetry;
        }

    }
}
