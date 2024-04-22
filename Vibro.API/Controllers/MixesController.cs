using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Vibro.API.Util;
using System.Text.Json;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/mixes")]
    public class MixesController(IMixRepository mixRepository, IMapper mapper, ILogger<MixesController> logger) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000, [FromQuery] Guid? vibeId = null)
        {
            logger.LogInformation("Getting all mixes");

            var mixes = await mixRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize, vibeId);

            logger.LogInformation($"Got all mixes with data: {JsonSerializer.Serialize(mixes)}");

            return Ok(mapper.Map<List<MixDto>>(mixes));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            logger.LogInformation($"Getting mix with id: {id}");

            var mix = await mixRepository.GetByIdAsync(id);

            if (mix == null) return NotFound();

            logger.LogInformation($"Got mix with data: {JsonSerializer.Serialize(mix)}");

            return Ok(mapper.Map<MixDto>(mix));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddMixRequestDto addMixRequestDto)
        {
            logger.LogInformation("Creating new mix");

            var newMix = mapper.Map<Mix>(addMixRequestDto);

            var createdMix = await mixRepository.CreateAsync(newMix);

            logger.LogInformation($"Created new mix with data: {JsonSerializer.Serialize(createdMix)}");

            return CreatedAtAction(nameof(Create), new { id = createdMix.Id }, mapper.Map<MixDto>(createdMix));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMixRequestDto updateMixRequestDto)
        {
            logger.LogInformation($"Updating mix with id: {id}");

            var existingMix = await mixRepository.UpdateAsync(id, mapper.Map<Mix>(updateMixRequestDto));

            if (existingMix == null) return NotFound();

            logger.LogInformation($"Updated mix with data: {JsonSerializer.Serialize(existingMix)}");

            return Ok(mapper.Map<MixDto>(existingMix));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            logger.LogInformation($"Deleting mix with id: {id}");

            var existingMix = await mixRepository.DeleteAsync(id);

            if (existingMix == null) return NotFound();

            logger.LogInformation($"Deleted mix with data: {JsonSerializer.Serialize(existingMix)}");

            return Ok(mapper.Map<MixDto>(existingMix));
        }
    }
}
