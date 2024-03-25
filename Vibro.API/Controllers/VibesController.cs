using Microsoft.AspNetCore.Mvc;
using Vibro.API.Data;
using Vibro.API.Models;
using Vibro.API.Models.DTO;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController : ControllerBase
    {
        private readonly VibroDbContext _db;

        public VibesController(VibroDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Vibe> vibes = _db.Vibes.ToList();

            List<VibeDto> vibesDto = [];
            foreach (var vibe in vibes)
            {
                vibesDto.Add(new VibeDto()
                {
                    Id = vibe.Id,
                    Name = vibe.Name,
                    Description = vibe.Description,
                    ArtUrl = vibe.ArtUrl,
                });
            }

            return Ok(vibes);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            Vibe? vibe = _db.Vibes.Find(id);

            if(vibe == null)
                return NotFound();

            var vibeDto = new VibeDto()
            {
                Id = vibe.Id,
                Name = vibe.Name,
                Description = vibe.Description,
                ArtUrl = vibe.ArtUrl,
            };

            return Ok(vibeDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddVibeRequestDto addVibeRequestDto)
        {
            var newVibe = new Vibe
            {
                Name = addVibeRequestDto.Name,
                Description = addVibeRequestDto.Description,
                ArtUrl = addVibeRequestDto.ArtUrl,
            };

            _db.Vibes.Add(newVibe);
            _db.SaveChanges();

            var vibeDto = new VibeDto
            {
                Id = newVibe.Id,
                Name = newVibe.Name,
                Description = newVibe.Description,
                ArtUrl = newVibe.ArtUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = vibeDto.Id }, vibeDto);
        }
    }
}
