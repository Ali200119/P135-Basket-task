using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddQuotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Description", "Image", "Name", "Position", "SoftDelete" },
                values: new object[] { 1, "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", "testimonial-img-1.png", "Anna Barnes", "Florist", false });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Description", "Image", "Name", "Position", "SoftDelete" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", "testimonial-img-2.png", "Jasmine White", "Florist", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
