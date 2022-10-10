using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HentaiSite.Migrations
{
    public partial class DateColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserViews");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Comments",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "Data");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UserViews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
