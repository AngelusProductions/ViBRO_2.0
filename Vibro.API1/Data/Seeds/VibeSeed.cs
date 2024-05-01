using Vibro.API1.Models;

namespace Vibro.API1.Data.Seeds
{
    public static class VibeSeed
    {
        public static List<Vibe> Data =
        [
            new Vibe
            {
                Id = Guid.Parse("A4044506-455E-47B2-A8CF-7DD16D42D182"),
                Name = "POST THAT SHIT!",
                Description = "A hip-hop beat for those about to post.",
                ArtUrl = "https://storage.googleapis.com/angelusproductions.com/vibes/art/postThatShit.webp"
            },
            new Vibe
            {
                Id = Guid.Parse("0E416981-389E-40EF-A96D-85E277D82B13"),
                Name = "Lofi Samba",
                Description = "A chill lofi beat with a Latin flavor.",
                ArtUrl = "https://storage.googleapis.com/angelusproductions.com/vibes/art/lofiSamba.webp"
            },
            new Vibe
            {
                Id = Guid.Parse("A89773DC-BD4C-48C7-9041-8B9F912FF596"),
                Name = "Bitch, I'm a Superhero!",
                Description = "A fun song about having superpowers.",
                ArtUrl = "https://storage.googleapis.com/angelusproductions.com/vibes/art/bitchImASuperhero.webp"
            },
            new Vibe
            {
                Id = Guid.Parse("08BD6E52-0AF4-4D2E-8EC0-DDDADD526E90"),
                Name = "Dance of the Fancy People",
                Description = "This song is only for the fanciest of people.",
                ArtUrl = "https://storage.googleapis.com/angelusproductions.com/vibes/art/danceOfTheFancyPeople.webp"
            }
        ];
    }
}
