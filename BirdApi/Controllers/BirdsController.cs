using BirdsApi.Data;
using BirdsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirdApi.Extensions;
using BirdApi.DTOs;
using BirdApi.Controllers;

namespace BirdsAPI.Controllers
{
    public class BirdsController : BaseApiController
    {
        private readonly BirdsContext _context;

        public BirdsController(BirdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BirdDto>>> GetBirds()
        {
            return await _context.Birds
                .Include(b => b.Sightings)
                .Select(b => b.ToDto())
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BirdDto>> GetBird(int id)
        {
            var bird = await _context.Birds.FindAsync(id);
            if (bird == null)
                return BadRequest("Bird not found");
            return Ok(bird.ToDto());
        }

        [HttpGet("{id}/sightings")]
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


    }

}
