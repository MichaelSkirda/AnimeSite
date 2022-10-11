using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeSite.Migrations
{
    public partial class CommentServiceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IPAddressBytes",
                table: "Comments",
                type: "varbinary(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddressBytes",
                table: "Comments");
        }
    }
}
