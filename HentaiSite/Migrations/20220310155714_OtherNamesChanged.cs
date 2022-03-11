using Microsoft.EntityFrameworkCore.Migrations;

namespace HentaiSite.Migrations
{
    public partial class OtherNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherNames",
                table: "Posts",
                newName: "OtherNamesString");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherNamesString",
                table: "Posts",
                newName: "OtherNames");
        }
    }
}
