namespace Vibro.API.Models.DTO
{
    public class AddVibeRequestDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string ArtUrl { get; set; }
    }
}
