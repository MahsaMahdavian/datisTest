using Microsoft.EntityFrameworkCore.Migrations;

namespace ConvertLinqApplication.Migrations
{
    public partial class removevisitfromurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId",
                unique: true);
        }
    }
}
