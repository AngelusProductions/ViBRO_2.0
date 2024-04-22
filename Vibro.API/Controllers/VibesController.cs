using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;
using Vibro.API.Util;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController(IVibeRepository vibeRepository, IMapper mapper, ILogger<VibesController> logger) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            logger.LogInformation("Getting all vibes");

            var vibes = await vibeRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            logger.LogInformation($"Got all vibes with data: ${JsonSerializer.Serialize(vibes)}");

            return Ok(mapper.Map<List<VibeDto>>(vibes));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            logger.LogInformation($"Getting vibe with id {id}");

            var vibe = await vibeRepository.GetByIdAsync(id);

            if(vibe == null) return NotFound();

            logger.LogInformation($"Got vibe with data: ${JsonSerializer.Serialize(vibe)}");

            return Ok(mapper.Map<VibeDto>(vibe));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddVibeRequestDto addVibeRequestDto)
        {
            logger.LogInformation("Creating new vibe");

            var newVibe = await vibeRepository.CreateAsync(mapper.Map<Vibe>(addVibeRequestDto));

            var vibeDto = mapper.Map<VibeDto>(newVibe);

            logger.LogInformation($"Created new vibe with data: ${JsonSerializer.Serialize(vibeDto)}");

            return CreatedAtAction(nameof(Create), new { id = vibeDto.Id }, vibeDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVibeRequestDto updateVibeRequestDto)
        {
            logger.LogInformation($"Updating vibe with id: {id}");

            var existingVibe = await vibeRepository.UpdateAsync(id, mapper.Map<Vibe>(updateVibeRequestDto));

            if (existingVibe == null) return NotFound();

            logger.LogInformation($"Updated vibe with data: ${JsonSerializer.Serialize(existingVibe)}");

            return Ok(mapper.Map<VibeDto>(existingVibe));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            logger.LogInformation($"Deleting vibe with id: {id}");

            var existingVibe = await vibeRepository.DeleteAsync(id);

            if (existingVibe == null) return NotFound();

            logger.LogInformation($"Deleted vibe with data: ${JsonSerializer.Serialize(existingVibe)}");

            return Ok(mapper.Map<VibeDto>(existingVibe));
        }
    }
}
