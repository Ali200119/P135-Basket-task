using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddAboutsAndAdvantagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advantages_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "SoftDelete", "Title", "VideoCover" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion...", false, "<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>", "h3-video-img.jpg" });

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "AboutId", "Description", "Icon", "SoftDelete" },
                values: new object[] { 1, 1, "Hand picked just for you.", "h1-custom-icon.png", false });

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "AboutId", "Description", "Icon", "SoftDelete" },
                values: new object[] { 2, 1, "Unique flower arrangements.", "h1-custom-icon.png", false });

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "AboutId", "Description", "Icon", "SoftDelete" },
                values: new object[] { 3, 1, "Best way to say you care.", "h1-custom-icon.png", false });

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_AboutId",
                table: "Advantages",
                column: "AboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
