using Microsoft.EntityFrameworkCore.Migrations;

namespace HentaiSite.Migrations
{
    public partial class ViewsChangedPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCountThisWeek",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCountToday",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCountThisWeek",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ViewCountToday",
                table: "Posts");
        }
    }
}
