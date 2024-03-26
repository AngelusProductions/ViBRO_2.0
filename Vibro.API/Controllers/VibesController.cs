using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Vibro.API.Data;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController(IVibeRepository vibeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vibes = await vibeRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById(Guid id)
        {
            var vibe = await vibeRepository.GetByIdAsync(id);

            if(vibe == null)
                return NotFound();

            return Ok(new VibeDto()
            {
                Id = vibe.Id,
                Name = vibe.Name,
                Description = vibe.Description,
                ArtUrl = vibe.ArtUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVibeRequestDto addVibeRequestDto)
        {
            var newVibe = await vibeRepository.CreateAsync(new Vibe
            {
                Name = addVibeRequestDto.Name,
                Description = addVibeRequestDto.Description,
                ArtUrl = addVibeRequestDto.ArtUrl,
            });

            return CreatedAtAction(nameof(Create), new { id = newVibe.Id }, new VibeDto
            {
                Id = newVibe.Id,
                Name = newVibe.Name,
                Description = newVibe.Description,
                ArtUrl = newVibe.ArtUrl,
            });
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVibeRequestDto updateVibeRequestDto)
        {

            var existingVibe = await vibeRepository.UpdateAsync(id, new Vibe ()
            {
                Name = updateVibeRequestDto.Name,
                Description = updateVibeRequestDto.Description,
                ArtUrl = updateVibeRequestDto.ArtUrl,
            });

            if (existingVibe == null)
                return NotFound();

            return Ok(new VibeDto
            {
                Id = existingVibe.Id,
                Name = existingVibe.Name,
                Description = existingVibe.Description,
                ArtUrl = existingVibe.ArtUrl,
            });
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var existingVibe = await vibeRepository.DeleteAsync(id);

            if (existingVibe == null)
                return NotFound();

            return Ok(new VibeDto
            {
                Id = existingVibe.Id,
                Name = existingVibe.Name,
                Description = existingVibe.Description,
                ArtUrl = existingVibe.ArtUrl,
            });
        }
    }
}
