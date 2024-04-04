using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Vibro.API.Util;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/mixes")]
    public class MixesController(IMixRepository mixRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000, [FromQuery] Guid? vibeId = null)
        {
            var mixes = await mixRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize, vibeId);

            return Ok(mapper.Map<List<MixDto>>(mixes));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var mix = await mixRepository.GetByIdAsync(id);

            if (mix == null) return NotFound();

            return Ok(mapper.Map<MixDto>(mix));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddMixRequestDto addMixRequestDto)
        {
            var newMix = mapper.Map<Mix>(addMixRequestDto);

            var createdMix = await mixRepository.CreateAsync(newMix);

            return CreatedAtAction(nameof(Create), new { id = createdMix.Id }, mapper.Map<MixDto>(createdMix));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMixRequestDto updateMixRequestDto)
        {
            var existingMix = await mixRepository.UpdateAsync(id, mapper.Map<Mix>(updateMixRequestDto));

            if (existingMix == null) return NotFound();

            return Ok(mapper.Map<MixDto>(existingMix));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var existingMix = await mixRepository.DeleteAsync(id);

            if (existingMix == null) return NotFound();

            return Ok(mapper.Map<MixDto>(existingMix));
        }
    }
}
