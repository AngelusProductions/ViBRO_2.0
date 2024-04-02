using System.ComponentModel.DataAnnotations;

namespace Vibro.API.Models.DTO
{
    public class AddVibeRequestDto
    {
        public required string Name { get; set; }

        [MinLength(3)]
        public required string Description { get; set; }

        public required string ArtUrl { get; set; }
    }
}
