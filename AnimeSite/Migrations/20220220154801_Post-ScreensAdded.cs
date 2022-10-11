using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeSite.Migrations
{
    public partial class PostScreensAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Format",
                table: "Posts",
                newName: "ImgFormat");

            migrationBuilder.AlterColumn<int>(
                name: "EndingYear",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScreenCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ScreenCount",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ImgFormat",
                table: "Posts",
                newName: "Format");

            migrationBuilder.AlterColumn<int>(
                name: "EndingYear",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
