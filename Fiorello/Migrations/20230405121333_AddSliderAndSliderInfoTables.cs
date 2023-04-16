using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddSliderAndSliderInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SliderInfo",
                columns: new[] { "Id", "Description", "SignatureImage", "SoftDelete", "Title" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.", "h2-sign-img.png", false, "<h1>Send <span>flowers</span> like</h1><h1>you mean it</h1>" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "h3-slider-background.jpg", false },
                    { 2, "h3-slider-background-2.jpg", false },
                    { 3, "h3-slider-background-3.jpg", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderInfo");

            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
