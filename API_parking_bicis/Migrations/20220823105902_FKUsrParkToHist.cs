using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_parking_bicis.Migrations
{
    public partial class FKUsrParkToHist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_ParkingId",
                table: "Histories",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Parkings_ParkingId",
                table: "Histories",
                column: "ParkingId",
                principalTable: "Parkings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Parkings_ParkingId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_ParkingId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_UserId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ParkingId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Histories");
        }
    }
}
