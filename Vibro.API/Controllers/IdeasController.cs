using AutoMapper;
using Vibro.API.Models;
using Vibro.API.Models.DTO;
using Vibro.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Vibro.API.Util;

namespace Vibro.API.Controllers
{
    [ApiController]
    [Route("api/ideas")]
    public class IdeasController(IIdeaRepository ideaRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000, [FromQuery] Guid? mixId = null)
        {
            var ideas = await ideaRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize, mixId);

            return Ok(mapper.Map<List<IdeaDto>>(ideas));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var idea = await ideaRepository.GetByIdAsync(id);

            if (idea == null) return NotFound();

            return Ok(mapper.Map<IdeaDto>(idea));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddIdeaRequestDto addIdeaRequestDto)
        {
            var newIdea = mapper.Map<Idea>(addIdeaRequestDto);

            var createdIdea = await ideaRepository.CreateAsync(newIdea);

            return CreatedAtAction(nameof(Create), new { id = createdIdea.Id }, mapper.Map<IdeaDto>(createdIdea));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIdeaRequestDto updateIdeaRequestDto)
        {
            var existingIdea = await ideaRepository.UpdateAsync(id, mapper.Map<Idea>(updateIdeaRequestDto));

            if (existingIdea == null) return NotFound();

            return Ok(mapper.Map<IdeaDto>(existingIdea));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var existingIdea = await ideaRepository.DeleteAsync(id);

            if (existingIdea == null) return NotFound();

            return Ok(mapper.Map<IdeaDto>(existingIdea));
        }
    }
}
