using Microsoft.EntityFrameworkCore.Migrations;

namespace ConvertLinqApplication.Migrations
{
    public partial class updFeildNameUrlid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Urls_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "UrlId",
                table: "Visits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UrlId",
                table: "Visits",
                column: "UrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Urls_UrlId",
                table: "Visits",
                column: "UrlId",
                principalTable: "Urls",
                principalColumn: "UrlId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Urls_UrlId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UrlId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Urls_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "Urls",
                principalColumn: "UrlId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
