namespace Vibro.API.Models.DTO
{
    public class MixDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Url { get; set; }

        public required int Number { get; set; }

        public required int Runtime { get; set; }

        public required Guid VibeId { get; set; }

        public required VibeDto Vibe { get; set; }
    }
}
