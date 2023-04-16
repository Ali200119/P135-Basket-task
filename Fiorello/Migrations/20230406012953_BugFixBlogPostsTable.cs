using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class BugFixBlogPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "blog-feature-img-3.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "blog-feature-img-4.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "blog-feature-img-2.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "blog-feature-img-3.jpg");
        }
    }
}
