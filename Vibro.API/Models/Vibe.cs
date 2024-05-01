namespace Vibro.API1.Models
{
    public class Vibe
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string ArtUrl { get; set; }
    }
}
