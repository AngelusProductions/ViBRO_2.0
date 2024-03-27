using Vibro.API.Models;

namespace Vibro.API.Data.Seeds
{
    public static class MixSeed
    {
        public static List<Mix> Data =
        [
            new Mix
            {
                Id = Guid.Parse("54EF1BF7-6668-4F13-AB65-0EFE55BBFD72"),
                Name = "Orchestral Mix",
                Description = "I substituted the voices for orchestra noises.",
                Number = 2,
                Runtime = 135,
                VibeId = Guid.Parse("08BD6E52-0AF4-4D2E-8EC0-DDDADD526E90"),
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Dance%20of%20the%20Fancy%20People%20%7C%20Orchestral.wav"
            },
            new Mix
            {
                Id = Guid.Parse("9D65CC87-87A5-4E5D-B063-16B69F7EBFB0"),
                Name = "Original Mix",
                Description = "This is the genesis of the idea.",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Brain%20Dancer.wav",
                Number = 1,
                Runtime = 18,
                VibeId = Guid.Parse("A89773DC-BD4C-48C7-9041-8B9F912FF596")
            },
            new Mix
            {
                Id = Guid.Parse("FEDA2A99-A2C0-474D-8105-2040ABEAA0C6"),
                Name = "Demo",
                Description = "Here is the demo I played for Epiphany Space",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/I'm%20a%20Superhero!%20(Demo).wav",
                Number = 3,
                Runtime = 69,
                VibeId = Guid.Parse("A89773DC-BD4C-48C7-9041-8B9F912FF596")
            },
            new Mix
            {
                Id = Guid.Parse("77E8E2A4-140E-4EE2-A4B1-8A7DEEA39931"),
                Name = "Original Mix",
                Description = "This is how it initially was created.",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Dance%20of%20the%20Fancy%20People.wav",
                Number = 1,
                Runtime = 138,
                VibeId = Guid.Parse("08BD6E52-0AF4-4D2E-8EC0-DDDADD526E90")
            },
            new Mix
            {
                Id = Guid.Parse("47665A2A-0015-46E9-BB44-A1FA0191782E"),
                Name = "More Fleshed Out Mix",
                Description = "Here I extended it into a short track",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/I'm%20a%20Superhero!.wav",
                Number = 2,
                Runtime = 50,
                VibeId = Guid.Parse("A89773DC-BD4C-48C7-9041-8B9F912FF596")
            },
            new Mix
            {
                Id = Guid.Parse("4E8D89E9-4C7B-424E-B561-C67282C99513"),
                Name = "Tay Eb Mix",
                Description = "They added their own feel to the groove",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Pisces%20Season%20Tay%20demo%20bounce.wav",
                Number = 2,
                Runtime = 172,
                VibeId = Guid.Parse("0E416981-389E-40EF-A96D-85E277D82B13")
            },
            new Mix
            {
                Id = Guid.Parse("1C134B6D-327A-4E20-93DE-D0948A53A2CF"),
                Name = "Initial Mix",
                Description = "This was written for the L&V soundtrack",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Lo-Fi%20Samba%20(03%3A05%3A2024).wav",
                Number = 1,
                Runtime = 172,
                VibeId = Guid.Parse("0E416981-389E-40EF-A96D-85E277D82B13")
            },
            new Mix
            {
                Id = Guid.Parse("7023C09E-BC53-4556-8903-DA35C3678F79"),
                Name = "Post That Shit Creation",
                Description = "We then turned it into POST THAT SHIT",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/POST%20THAT%20SHIT!.wav",
                Number = 2,
                Runtime = 71,
                VibeId = Guid.Parse("A4044506-455E-47B2-A8CF-7DD16D42D182")
            },
            new Mix
            {
                Id = Guid.Parse("7250216C-7BB1-4FAF-891E-EA8999DEDD62"),
                Name = "Original Mix",
                Description = "This is the first go around for this track.",
                Url = "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/GuardianVideo.wav",
                Number = 1,
                Runtime = 23,
                VibeId = Guid.Parse("A4044506-455E-47B2-A8CF-7DD16D42D182")
            }
        ];
    }
}
