using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddInstagramsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instagrams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instagrams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Instagrams",
                columns: new[] { "Id", "Image", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "instagram1.jpg", false },
                    { 2, "instagram2.jpg", false },
                    { 3, "instagram3.jpg", false },
                    { 4, "instagram4.jpg", false },
                    { 5, "instagram5.jpg", false },
                    { 6, "instagram6.jpg", false },
                    { 7, "instagram7.jpg", false },
                    { 8, "instagram8.jpg", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instagrams");
        }
    }
}
