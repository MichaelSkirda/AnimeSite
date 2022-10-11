using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeSite.Migrations
{
    public partial class PreviewChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPreview",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPreview",
                table: "Studios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Studios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPreview",
                table: "Directors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPreview",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "HasPreview",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "HasPreview",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Directors");
        }
    }
}
