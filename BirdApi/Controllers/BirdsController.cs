using BirdsApi.Data;
using BirdsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirdsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly BirdsContext _context;

        public BirdsController(BirdsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bird>>> GetBirds()
        {
            return await _context.Birds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bird>> GetBird(int id)
        {
            var bird = await _context.Birds.FindAsync(id);
            if (bird == null)
                return BadRequest("Bird not found");
            return Ok(bird);
        }


    }

}
