namespace Vibro.API1.Models.DTO
{
    public class VibeDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string ArtUrl { get; set; }
    }
}
