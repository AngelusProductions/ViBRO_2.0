using System.Text.Json;
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
    [Route("api/ideas")]
    public class IdeasController(IIdeaRepository ideaRepository, IMapper mapper, ILogger<IdeasController> _logger) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000, [FromQuery] Guid? mixId = null)
        {
            _logger.LogInformation("Getting all ideas");

            var ideas = await ideaRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize, mixId);

            _logger.LogInformation($"Got all ideas with data: {JsonSerializer.Serialize(ideas)}");

            return Ok(mapper.Map<List<IdeaDto>>(ideas));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation($"Getting idea with id: {id}");

            var idea = await ideaRepository.GetByIdAsync(id);

            if (idea == null) return NotFound();

            _logger.LogInformation($"Got idea with data: {JsonSerializer.Serialize(idea)}");

            return Ok(mapper.Map<IdeaDto>(idea));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddIdeaRequestDto addIdeaRequestDto)
        {
            _logger.LogInformation("Creating new idea");

            var newIdea = mapper.Map<Idea>(addIdeaRequestDto);

            var createdIdea = await ideaRepository.CreateAsync(newIdea);

            _logger.LogInformation($"Created new idea with data: {JsonSerializer.Serialize(createdIdea)}");

            return CreatedAtAction(nameof(Create), new { id = createdIdea.Id }, mapper.Map<IdeaDto>(createdIdea));
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIdeaRequestDto updateIdeaRequestDto)
        {
            _logger.LogInformation($"Updating idea with id: {id}");

            var existingIdea = await ideaRepository.UpdateAsync(id, mapper.Map<Idea>(updateIdeaRequestDto));

            if (existingIdea == null) return NotFound();

            _logger.LogInformation($"Updated idea with data: {JsonSerializer.Serialize(existingIdea)}");

            return Ok(mapper.Map<IdeaDto>(existingIdea));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            _logger.LogInformation($"Deleting idea with id: {id}");

            var existingIdea = await ideaRepository.DeleteAsync(id);

            if (existingIdea == null) return NotFound();

            _logger.LogInformation($"Deleted idea with data: {JsonSerializer.Serialize(existingIdea)}");

            return Ok(mapper.Map<IdeaDto>(existingIdea));
        }
    }
}
