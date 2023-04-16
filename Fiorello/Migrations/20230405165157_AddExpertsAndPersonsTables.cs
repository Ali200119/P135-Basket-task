using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddExpertsAndPersonsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Description", "SoftDelete", "Title" },
                values: new object[] { 1, "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", false, "Flower Experts" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "ExpertId", "Image", "Name", "Position", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 1, "h3-team-img-1.png", "CRYSTAL BROOKS", "Florist", false },
                    { 2, 1, "h3-team-img-2.png", "SHIRLEY HARRIS", "Manager", false },
                    { 3, 1, "h3-team-img-3.png", "BEVERLY CLARK", "Florist", false },
                    { 4, 1, "h3-team-img-4.png", "AMANDA WATKINS", "Florist", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ExpertId",
                table: "Persons",
                column: "ExpertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Experts");
        }
    }
}
