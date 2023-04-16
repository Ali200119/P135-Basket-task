using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class AddBlogsAndBlogPostsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
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
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "SoftDelete", "Title" },
                values: new object[] { 1, "A perfect blend of creativity, energy, communication, happiness and love. Let us arrange a smile for you.", false, "From our Blog" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogId", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 1, 1, new DateTime(2019, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-1.jpg", false, "Flower Power" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogId", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 2, 1, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-2.jpg", false, "Local Florists" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogId", "Date", "Description", "Image", "SoftDelete", "Title" },
                values: new object[] { 3, 1, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-3.jpg", false, "Flower Beauty" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogId",
                table: "BlogPosts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
