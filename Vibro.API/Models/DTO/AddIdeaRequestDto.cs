using System.ComponentModel.DataAnnotations;

namespace Vibro.API.Models.DTO
{
    public class UpdateIdeaRequestDto
    {
        public required string Name { get; set; }

        [MinLength(3)]
        public required string Description { get; set; }

        [Range(0, int.MaxValue)]
        public required int Timestamp { get; set; }

        public required Guid MixId { get; set; }
    }
}
