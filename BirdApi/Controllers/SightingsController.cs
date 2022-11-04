using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirdsApi.Data;
using BirdsApi.Models;
using BirdApi.DTOs;
using BirdApi.Extensions;

namespace BirdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingsController : ControllerBase
    {
        private readonly BirdsContext _context;

        public SightingsController(BirdsContext context)
        {
            _context = context;
        }

        // GET: api/Sightings
        // change to use DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SightingDto>>> GetSighting()
        {
            return await _context.Sighting
                .Include(s => s.Bird)
                .Select(s => s.ToDto())
                .ToListAsync();
        }

        // GET: api/Sightings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sighting>> GetSighting(int id)
        {
            var sighting = await _context.Sighting.FindAsync(id);

            if (sighting == null)
            {
                return NotFound();
            }

            return sighting;
        }

        [HttpGet("bird/{id}")]
        public async Task<ActionResult<List<Sighting>>> GetSightingByBird(int id)
        {
            var sightings = await _context.Sighting
                .Where(x => x.BirdId == id)
                .ToListAsync();

            if (sightings == null)
            {
                return NotFound();
            }

            return sightings;
        }

        // PUT: api/Sightings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSighting(int id, Sighting sighting)
        {
            if (id != sighting.SightingId)
            {
                return BadRequest();
            }

            _context.Entry(sighting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightingExists(id))
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

        // POST: api/Sightings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sighting>> PostSighting(Sighting sighting)
        {
            _context.Sighting.Add(sighting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSighting", new { id = sighting.SightingId }, sighting);
        }

        // DELETE: api/Sightings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSighting(int id)
        {
            var sighting = await _context.Sighting.FindAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }

            _context.Sighting.Remove(sighting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SightingExists(int id)
        {
            return _context.Sighting.Any(e => e.SightingId == id);
        }
    }
}
