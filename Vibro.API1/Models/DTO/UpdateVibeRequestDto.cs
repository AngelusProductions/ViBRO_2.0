using System.ComponentModel.DataAnnotations;

namespace Vibro.API1.Models.DTO
{
    public class UpdateVibeRequestDto
    {
        public required string Name { get; set; }

        [MinLength(3)]
        public required string Description { get; set; }

        public required string ArtUrl { get; set; }
    }
}
