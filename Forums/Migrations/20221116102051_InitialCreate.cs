using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forums.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ownership = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reported = table.Column<bool>(type: "bit", nullable: false),
                    Amountoflikes = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Amountoflikes", "DateOfAdded", "Description", "MovieId", "Ownership", "Reported", "Title" },
                values: new object[,]
                {
                    { new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), 4, new DateTime(2022, 11, 16, 11, 20, 51, 634, DateTimeKind.Local).AddTicks(2679), "I don't think this is a good movie at all! It contains a lot of bad filming.", 42543, new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), false, "Is the Star-Wars - Rise of Empire movie good?" },
                    { new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), 245, new DateTime(2022, 11, 16, 11, 20, 51, 634, DateTimeKind.Local).AddTicks(2716), "Just Hagrid in the movie?!.", 5345, new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), false, "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
