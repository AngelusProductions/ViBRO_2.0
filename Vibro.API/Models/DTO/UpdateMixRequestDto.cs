namespace Vibro.API.Models.DTO
{
    public class UpdateMixRequestDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Url { get; set; }

        public required int Number { get; set; }

        public required int Runtime { get; set; }

        public required Guid VibeId { get; set; }
    }
}
