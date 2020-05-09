using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConvertLinqApplication.Migrations
{
    public partial class addColoumnVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeVisit",
                table: "Visits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserIP",
                table: "Visits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeVisit",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserIP",
                table: "Visits");
        }
    }
}
