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
        public async Task<ActionResult<SightingDto>> GetSighting(int id)
        {
            var sighting = await _context.Sighting.Include(s => s.Bird)
                .FirstOrDefaultAsync(s => s.SightingId == id);

            if (sighting == null)
            {
                return NotFound();
            }

            return sighting.ToDto();
        }

        [HttpGet("bird/{id}")]
        public async Task<ActionResult<List<SightingDto>>> GetSightingByBird(int id)
        {
            var sightings = await _context.Sighting
                .Include(s => s.Bird)
                .Where(x => x.BirdId == id)
                .Select(s => s.ToDto())
                .ToListAsync();

            if (sightings == null)
            {
                return NotFound();
            }

            return sightings;
        }

        // PUT: api/Sightings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSighting(SightingDtoUpdate sightingDto)
        {
            var sighting = await _context.Sighting.FindAsync(sightingDto.Id);

            if (sighting == null) return NotFound();

            sighting.BirdId = sightingDto.BirdId;
            sighting.Date = sightingDto.Date;
            sighting.Place = sightingDto.Place;
            sighting.Comment = sightingDto.Comment;

            await _context.SaveChangesAsync();

            return Ok(sighting);
        }

        // POST: api/Sightings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sighting>> PostSighting(SightingDtoCreate sightingDto)
        {
            var sighting = new Sighting
            {
                BirdId = sightingDto.BirdId,
                Date = sightingDto.Date,
                Comment = sightingDto.Comment,
                Place = sightingDto.Place,
            };
            _context.Sighting.Add(sighting);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSighting), new { id = sighting.SightingId}, sighting);
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
