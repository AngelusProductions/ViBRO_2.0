using Vibro.API1.Models;

namespace Vibro.API1.Data.Seeds
{
    public static class IdeaSeed
    {
        public static List<Idea> Data =
        [
            new Idea
            {
                Id = Guid.Parse("5CA04137-4779-4902-A925-1111AB77ADCD"),
                Name = "Bassoon Noise",
                Description = "Maybe add a bassoon sound here",
                Timestamp = 33,
                MixId = Guid.Parse("54EF1BF7-6668-4F13-AB65-0EFE55BBFD72")
            },
            new Idea
            {
                Id = Guid.Parse("9D65CC87-87A5-4E5D-B063-16B69F7EBFB0"),
                Name = "Bass Note",
                Description = "That bass synth sounds best here",
                Timestamp = 3,
                MixId = Guid.Parse("9D65CC87-87A5-4E5D-B063-16B69F7EBFB0")
            },
            new Idea
            {
                Id = Guid.Parse("6444DDD9-6E84-4057-A397-5151D70F02A6"),
                Name = "Vocal Compliment",
                Description = "Your vox sound great",    
                Timestamp = 5 ,
                MixId = Guid.Parse("FEDA2A99-A2C0-474D-8105-2040ABEAA0C6")
            },
            new Idea
            {
                Id = Guid.Parse("D83124DD-7377-4478-800F-6EE27EF85A7A"),
                Name = "Bridge Idea",
                Description = "Maybe go into a bridge here",
                Timestamp = 20,
                MixId = Guid.Parse("7023C09E-BC53-4556-8903-DA35C3678F79")
            },
            new Idea
            {
                Id = Guid.Parse("2C9D8F58-4EFC-47DE-A76D-8B57BBCD8DD0"),
                Name = "Instrument Advice",
                Description = "I think the instruments sound too generic",
                Timestamp = 0 ,
                MixId = Guid.Parse("54EF1BF7-6668-4F13-AB65-0EFE55BBFD72")
            },
            new Idea
            {
                Id = Guid.Parse("E16093D5-225F-4B6C-8EB2-9E6AB2804DFC"),
                Name = "Bass Idea",
                Description = "Maybe you could add a bass drop here",
                Timestamp = 60,
                MixId = Guid.Parse("FEDA2A99-A2C0-474D-8105-2040ABEAA0C6")
            },
            new Idea
            {
                Id = Guid.Parse("57CF54E6-92CE-493D-A235-DB1287012601"),
                Name = "Great start",
                Description = "This track has a lot of promise",
                Timestamp = 0 ,
                MixId = Guid.Parse("7250216C-7BB1-4FAF-891E-EA8999DEDD62")
            },
            new Idea
            {
                Id = Guid.Parse("454750B9-F65E-473B-96B2-E67B378BBCD8"),
                Name = "Nice Voice",
                Description = "Her voice sounds the best here",
                Timestamp = 25,
                MixId = Guid.Parse("4E8D89E9-4C7B-424E-B561-C67282C99513")
            }
        ];
    }
}
