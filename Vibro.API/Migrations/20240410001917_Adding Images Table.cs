using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vibro.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vibes",
                columns: new[] { "Id", "ArtUrl", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("08bd6e52-0af4-4d2e-8ec0-dddadd526e90"), "https://storage.googleapis.com/angelusproductions.com/vibes/art/danceOfTheFancyPeople.webp", "This song is only for the fanciest of people.", "Dance of the Fancy People" },
                    { new Guid("0e416981-389e-40ef-a96d-85e277d82b13"), "https://storage.googleapis.com/angelusproductions.com/vibes/art/lofiSamba.webp", "A chill lofi beat with a Latin flavor.", "Lofi Samba" },
                    { new Guid("a4044506-455e-47b2-a8cf-7dd16d42d182"), "https://storage.googleapis.com/angelusproductions.com/vibes/art/postThatShit.webp", "A hip-hop beat for those about to post.", "POST THAT SHIT!" },
                    { new Guid("a89773dc-bd4c-48c7-9041-8b9f912ff596"), "https://storage.googleapis.com/angelusproductions.com/vibes/art/bitchImASuperhero.webp", "A fun song about having superpowers.", "Bitch, I'm a Superhero!" }
                });

            migrationBuilder.InsertData(
                table: "Mixes",
                columns: new[] { "Id", "Description", "Name", "Number", "Runtime", "Url", "VibeId" },
                values: new object[,]
                {
                    { new Guid("1c134b6d-327a-4e20-93de-d0948a53a2cf"), "This was written for the L&V soundtrack", "Initial Mix", 1, 172, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Lo-Fi%20Samba%20(03%3A05%3A2024).wav", new Guid("0e416981-389e-40ef-a96d-85e277d82b13") },
                    { new Guid("47665a2a-0015-46e9-bb44-a1fa0191782e"), "Here I extended it into a short track", "More Fleshed Out Mix", 2, 50, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/I'm%20a%20Superhero!.wav", new Guid("a89773dc-bd4c-48c7-9041-8b9f912ff596") },
                    { new Guid("4e8d89e9-4c7b-424e-b561-c67282c99513"), "They added their own feel to the groove", "Tay Eb Mix", 2, 172, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Pisces%20Season%20Tay%20demo%20bounce.wav", new Guid("0e416981-389e-40ef-a96d-85e277d82b13") },
                    { new Guid("54ef1bf7-6668-4f13-ab65-0efe55bbfd72"), "I substituted the voices for orchestra noises.", "Orchestral Mix", 2, 135, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Dance%20of%20the%20Fancy%20People%20%7C%20Orchestral.wav", new Guid("08bd6e52-0af4-4d2e-8ec0-dddadd526e90") },
                    { new Guid("7023c09e-bc53-4556-8903-da35c3678f79"), "We then turned it into POST THAT SHIT", "Post That Shit Creation", 2, 71, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/POST%20THAT%20SHIT!.wav", new Guid("a4044506-455e-47b2-a8cf-7dd16d42d182") },
                    { new Guid("7250216c-7bb1-4faf-891e-ea8999dedd62"), "This is the first go around for this track.", "Original Mix", 1, 23, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/GuardianVideo.wav", new Guid("a4044506-455e-47b2-a8cf-7dd16d42d182") },
                    { new Guid("77e8e2a4-140e-4ee2-a4b1-8a7deea39931"), "This is how it initially was created.", "Original Mix", 1, 138, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Dance%20of%20the%20Fancy%20People.wav", new Guid("08bd6e52-0af4-4d2e-8ec0-dddadd526e90") },
                    { new Guid("9d65cc87-87a5-4e5d-b063-16b69f7ebfb0"), "This is the genesis of the idea.", "Original Mix", 1, 18, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/Brain%20Dancer.wav", new Guid("a89773dc-bd4c-48c7-9041-8b9f912ff596") },
                    { new Guid("feda2a99-a2c0-474d-8105-2040abeaa0c6"), "Here is the demo I played for Epiphany Space", "Demo", 3, 69, "https://storage.googleapis.com/angelusproductions.com/vibes/mixes/I'm%20a%20Superhero!%20(Demo).wav", new Guid("a89773dc-bd4c-48c7-9041-8b9f912ff596") }
                });

            migrationBuilder.InsertData(
                table: "Ideas",
                columns: new[] { "Id", "Description", "MixId", "Name", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("2c9d8f58-4efc-47de-a76d-8b57bbcd8dd0"), "I think the instruments sound too generic", new Guid("54ef1bf7-6668-4f13-ab65-0efe55bbfd72"), "Instrument Advice", 0 },
                    { new Guid("454750b9-f65e-473b-96b2-e67b378bbcd8"), "Her voice sounds the best here", new Guid("4e8d89e9-4c7b-424e-b561-c67282c99513"), "Nice Voice", 25 },
                    { new Guid("57cf54e6-92ce-493d-a235-db1287012601"), "This track has a lot of promise", new Guid("7250216c-7bb1-4faf-891e-ea8999dedd62"), "Great start", 0 },
                    { new Guid("5ca04137-4779-4902-a925-1111ab77adcd"), "Maybe add a bassoon sound here", new Guid("54ef1bf7-6668-4f13-ab65-0efe55bbfd72"), "Bassoon Noise", 33 },
                    { new Guid("6444ddd9-6e84-4057-a397-5151d70f02a6"), "Your vox sound great", new Guid("feda2a99-a2c0-474d-8105-2040abeaa0c6"), "Vocal Compliment", 5 },
                    { new Guid("9d65cc87-87a5-4e5d-b063-16b69f7ebfb0"), "That bass synth sounds best here", new Guid("9d65cc87-87a5-4e5d-b063-16b69f7ebfb0"), "Bass Note", 3 },
                    { new Guid("d83124dd-7377-4478-800f-6ee27ef85a7a"), "Maybe go into a bridge here", new Guid("7023c09e-bc53-4556-8903-da35c3678f79"), "Bridge Idea", 20 },
                    { new Guid("e16093d5-225f-4b6c-8eb2-9e6ab2804dfc"), "Maybe you could add a bass drop here", new Guid("feda2a99-a2c0-474d-8105-2040abeaa0c6"), "Bass Idea", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("2c9d8f58-4efc-47de-a76d-8b57bbcd8dd0"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("454750b9-f65e-473b-96b2-e67b378bbcd8"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("57cf54e6-92ce-493d-a235-db1287012601"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("5ca04137-4779-4902-a925-1111ab77adcd"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("6444ddd9-6e84-4057-a397-5151d70f02a6"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("9d65cc87-87a5-4e5d-b063-16b69f7ebfb0"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("d83124dd-7377-4478-800f-6ee27ef85a7a"));

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: new Guid("e16093d5-225f-4b6c-8eb2-9e6ab2804dfc"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("1c134b6d-327a-4e20-93de-d0948a53a2cf"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("47665a2a-0015-46e9-bb44-a1fa0191782e"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("77e8e2a4-140e-4ee2-a4b1-8a7deea39931"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("4e8d89e9-4c7b-424e-b561-c67282c99513"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("54ef1bf7-6668-4f13-ab65-0efe55bbfd72"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("7023c09e-bc53-4556-8903-da35c3678f79"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("7250216c-7bb1-4faf-891e-ea8999dedd62"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("9d65cc87-87a5-4e5d-b063-16b69f7ebfb0"));

            migrationBuilder.DeleteData(
                table: "Mixes",
                keyColumn: "Id",
                keyValue: new Guid("feda2a99-a2c0-474d-8105-2040abeaa0c6"));

            migrationBuilder.DeleteData(
                table: "Vibes",
                keyColumn: "Id",
                keyValue: new Guid("08bd6e52-0af4-4d2e-8ec0-dddadd526e90"));

            migrationBuilder.DeleteData(
                table: "Vibes",
                keyColumn: "Id",
                keyValue: new Guid("0e416981-389e-40ef-a96d-85e277d82b13"));

            migrationBuilder.DeleteData(
                table: "Vibes",
                keyColumn: "Id",
                keyValue: new Guid("a4044506-455e-47b2-a8cf-7dd16d42d182"));

            migrationBuilder.DeleteData(
                table: "Vibes",
                keyColumn: "Id",
                keyValue: new Guid("a89773dc-bd4c-48c7-9041-8b9f912ff596"));
        }
    }
}
