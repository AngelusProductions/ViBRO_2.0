using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController(IVibeRepository vibeRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vibes = await vibeRepository.GetAllAsync();

            return Ok(mapper.Map<List<VibeDto>>(vibes));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vibe = await vibeRepository.GetByIdAsync(id);

            if(vibe == null) return NotFound();

            return Ok(mapper.Map<VibeDto>(vibe));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVibeRequestDto addVibeRequestDto)
        {
            var newVibe = await vibeRepository.CreateAsync(mapper.Map<Vibe>(addVibeRequestDto));

            var vibeDto = mapper.Map<VibeDto>(newVibe);

            return CreatedAtAction(nameof(Create), new { id = vibeDto.Id }, vibeDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVibeRequestDto updateVibeRequestDto)
        {
            var existingVibe = await vibeRepository.UpdateAsync(id, mapper.Map<Vibe>(updateVibeRequestDto));

            if (existingVibe == null) return NotFound();

            return Ok(mapper.Map<VibeDto>(existingVibe));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var existingVibe = await vibeRepository.DeleteAsync(id);

            if (existingVibe == null) return NotFound();

            return Ok(mapper.Map<VibeDto>(existingVibe));
        }
    }
}
