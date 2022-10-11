using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeSite.Migrations
{
    public partial class AdminFavoritePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdminFavorite",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminFavorite",
                table: "Posts");
        }
    }
}
