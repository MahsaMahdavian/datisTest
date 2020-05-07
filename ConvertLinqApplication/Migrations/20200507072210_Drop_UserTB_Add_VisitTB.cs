using Microsoft.EntityFrameworkCore.Migrations;

namespace ConvertLinqApplication.Migrations
{
    public partial class Drop_UserTB_Add_VisitTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Users_UserId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Urls_UserId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "CountVisit",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Urls");

            migrationBuilder.AlterColumn<string>(
                name: "ConvertedUrl",
                table: "Urls",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountVisit = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Urls_UserId",
                        column: x => x.UserId,
                        principalTable: "Urls",
                        principalColumn: "UrlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.AlterColumn<string>(
                name: "ConvertedUrl",
                table: "Urls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountVisit",
                table: "Urls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Urls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UserId",
                table: "Urls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Users_UserId",
                table: "Urls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
