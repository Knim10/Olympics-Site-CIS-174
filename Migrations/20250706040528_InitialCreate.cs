using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OlympicGamesSite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Category", "Country", "Game", "SportName" },
                values: new object[,]
                {
                    { 1, "Outdoor", "Austria", "Paralympics", "Canoe Sprint" },
                    { 2, "Outdoor", "Brazil", "Summer Olympics", "Road Cycling" },
                    { 3, "Indoor", "Canada", "Winter Olympics", "Curling" },
                    { 4, "Indoor", "China", "Summer Olympics", "Diving" },
                    { 5, "Indoor", "Cyprus", "Youth Olympic Games", "Breakdancing" },
                    { 6, "Outdoor", "Finland", "Youth Olympic Games", "Skateboarding" },
                    { 7, "Indoor", "France", "Youth Olympic Games", "Breakdancing" },
                    { 8, "Indoor", "Germany", "Summer Olympics", "Diving" },
                    { 9, "Indoor", "Great Britain", "Winter Olympics", "Curling" },
                    { 10, "Outdoor", "Italy", "Winter Olympics", "Bobsleigh" },
                    { 11, "Outdoor", "Jamaica", "Winter Olympics", "Bobsleigh" },
                    { 12, "Outdoor", "Japan", "Winter Olympics", "Bobsleigh" },
                    { 13, "Indoor", "Mexico", "Summer Olympics", "Diving" },
                    { 14, "Outdoor", "Netherlands", "Summer Olympics", "Cycling" },
                    { 15, "Outdoor", "Pakistan", "Paralympics", "Canoe Sprint" },
                    { 16, "Outdoor", "Portugal", "Youth Olympic Games", "Skateboarding" },
                    { 17, "Indoor", "Russia", "Youth Olympic Games", "Breakdancing" },
                    { 18, "Outdoor", "Slovakia", "Youth Olympic Games", "Skateboarding" },
                    { 19, "Indoor", "Sweden", "Winter Olympics", "Curling" },
                    { 20, "Indoor", "Thailand", "Paralympics", "Archery" },
                    { 21, "Indoor", "Ukraine", "Paralympics", "Archery" },
                    { 22, "Indoor", "Uruguay", "Paralympics", "Archery" },
                    { 23, "Outdoor", "USA", "Summer Olympics", "Road Cycling" },
                    { 24, "Outdoor", "Zimbabwe", "Paralympics", "Canoe Sprint" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
