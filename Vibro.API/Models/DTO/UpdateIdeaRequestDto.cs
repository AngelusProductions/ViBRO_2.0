namespace Vibro.API.Models.DTO
{
    public class AddIdeaRequestDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Timestamp { get; set; }

        public required Guid MixId { get; set; }
    }
}
