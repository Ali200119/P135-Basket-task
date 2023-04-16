using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddProductsCategoriesAndProductImagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "Popular", false },
                    { 2, "Winter", false },
                    { 3, "Various", false },
                    { 4, "Exotic", false },
                    { 5, "Greens", false },
                    { 6, "Cactuses", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Name", "Price", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 6, 20, "Lorem ipsum", "1MAJESTY PALM", 259m, false },
                    { 2, 4, 20, "Lorem ipsum", "2MAJESTY PALM", 259m, false },
                    { 3, 3, 20, "Lorem ipsum", "3MAJESTY PALM", 259m, false },
                    { 4, 1, 20, "Lorem ipsum", "4MAJESTY PALM", 259m, false },
                    { 5, 2, 20, "Lorem ipsum", "5MAJESTY PALM", 259m, false },
                    { 6, 2, 20, "Lorem ipsum", "6MAJESTY PALM", 259m, false },
                    { 7, 4, 20, "Lorem ipsum", "7MAJESTY PALM", 259m, false },
                    { 8, 5, 20, "Lorem ipsum", "8MAJESTY PALM", 259m, true },
                    { 9, 5, 20, "Lorem ipsum", "9MAJESTY PALM", 259m, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMain", "Name", "ProductId", "SoftDelete" },
                values: new object[,]
                {
                    { 1, true, "shop-14-img.jpg", 1, false },
                    { 2, false, "shop-13-img.jpg", 1, false },
                    { 3, false, "shop-12-img.jpg", 1, false },
                    { 4, false, "shop-13-img.jpg", 2, false },
                    { 5, true, "shop-14-img.jpg", 2, false },
                    { 6, true, "shop-11-img.jpg", 3, false },
                    { 7, false, "shop-10-img.jpg", 3, false },
                    { 8, false, "shop-9-img.jpg", 3, false },
                    { 9, true, "shop-11-img.jpg", 4, false },
                    { 10, false, "shop-12-img.jpg", 4, false },
                    { 11, true, "shop-10-img.jpg", 5, false },
                    { 12, false, "shop-13-img.jpg", 5, false },
                    { 13, true, "shop-9-img.jpg", 6, false },
                    { 14, false, "shop-14-img.jpg", 6, false },
                    { 15, true, "shop-8-img.jpg", 7, false },
                    { 16, false, "shop-11-img.jpg", 7, false },
                    { 17, false, "shop-9-img.jpg", 7, false },
                    { 18, true, "shop-7-img.jpg", 8, false },
                    { 19, false, "shop-10-img.jpg", 8, false },
                    { 20, true, "shop-14-img.jpg", 9, false },
                    { 21, false, "shop-8-img.jpg", 9, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
