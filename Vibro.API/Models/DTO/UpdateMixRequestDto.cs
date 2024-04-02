using System.ComponentModel.DataAnnotations;

namespace Vibro.API.Models.DTO
{
    public class UpdateMixRequestDto
    {
        public required string Name { get; set; }

        [MinLength(3)]
        public required string Description { get; set; }

        public required string Url { get; set; }

        [Range(1, int.MaxValue)]
        public required int Number { get; set; }

        [Range(1, int.MaxValue)]
        public required int Runtime { get; set; }

        public required Guid VibeId { get; set; }
    }
}
