using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirdsApi.Data;
using BirdsApi.Models;
using BirdApi.DTOs;
using BirdApi.Extensions;
using System;

namespace BirdApi.Controllers
{
    public class SightingsController : BaseApiController
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

        // PUT: api/Sightings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSighting(SightingDtoUpdate sightingDto)
        {
            var sighting = await _context.Sighting.FindAsync(sightingDto.Id);

            if (sighting == null) return NotFound();

            if (!DateOnly.TryParse(sightingDto.Date, out DateOnly result)) return ValidationProblem();

            sighting.BirdId = sightingDto.BirdId;
            sighting.Date = result;
            sighting.Place = sightingDto.Place;
            sighting.Comment = sightingDto.Comment;

            await _context.SaveChangesAsync();

            return Ok(sightingDto);
        }

        // POST: api/Sightings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SightingDto>> PostSighting(SightingDtoCreate sightingDto)
        {
            if (!DateOnly.TryParse(sightingDto.Date, out DateOnly resultD)) return ValidationProblem();

            var sighting = new Sighting
            {
                BirdId = sightingDto.BirdId,
                Date = resultD,
                Comment = sightingDto.Comment,
                Place = sightingDto.Place,
            };
            _context.Sighting.Add(sighting);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return CreatedAtAction(nameof(GetSighting), new { id = sighting.SightingId }, sightingDto);

            return BadRequest(new ProblemDetails { Title = "Problem adding sighting" });
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
