﻿namespace Vibro.API1.Models.DTO
{
    public class IdeaDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Timestamp { get; set; }

        public required Guid MixId { get; set; }

        public required MixDto Mix { get; set; }
    }
}
