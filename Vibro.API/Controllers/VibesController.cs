using Microsoft.AspNetCore.Mvc;
using Vibro.API.Data;
using Vibro.API.Models;
using Vibro.API.Models.DTO;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController(VibroDbContext db) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Vibe> vibes = [.. db.Vibes];

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

            return Ok(vibesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var vibe = db.Vibes.Find(id);

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

            db.Vibes.Add(newVibe);
            db.SaveChanges();

            var vibeDto = new VibeDto
            {
                Id = newVibe.Id,
                Name = newVibe.Name,
                Description = newVibe.Description,
                ArtUrl = newVibe.ArtUrl,
            };

            return CreatedAtAction(nameof(Create), new { id = vibeDto.Id }, vibeDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateVibeRequestDto updateVibeRequestDto)
        {
            var existingVibe = db.Vibes.FirstOrDefault(v => v.Id == id);

            if (existingVibe == null)
                return NotFound();

            existingVibe.Name = updateVibeRequestDto.Name;
            existingVibe.Description = updateVibeRequestDto.Description;
            existingVibe.ArtUrl = updateVibeRequestDto.ArtUrl;

            db.SaveChanges();

            var newVibeDto = new VibeDto
            {
                Id = existingVibe.Id,
                Name = existingVibe.Name,
                Description = existingVibe.Description,
                ArtUrl = existingVibe.ArtUrl,
            };

            return Ok(newVibeDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var existingVibe = db.Vibes.FirstOrDefault(v => v.Id == id);

            if (existingVibe == null)
                return NotFound();

            db.Vibes.Remove(existingVibe);
            db.SaveChanges();

            var deletedVibeDto = new VibeDto
            {
                Id = existingVibe.Id,
                Name = existingVibe.Name,
                Description = existingVibe.Description,
                ArtUrl = existingVibe.ArtUrl,
            };

            return Ok(deletedVibeDto);
        }
    }
}
