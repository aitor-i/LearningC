using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_parking_bicis.Migrations
{
    public partial class fix_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Parkings_ParkingId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Parkings",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_UserId",
                table: "Parkings",
                newName: "IX_Parkings_UsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Histories",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ParkingId",
                table: "Histories",
                newName: "ParkingsId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                newName: "IX_Histories_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_ParkingId",
                table: "Histories",
                newName: "IX_Histories_ParkingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Parkings_ParkingsId",
                table: "Histories",
                column: "ParkingsId",
                principalTable: "Parkings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Users_UsersId",
                table: "Histories",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Users_UsersId",
                table: "Parkings",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Parkings_ParkingsId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Users_UsersId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Users_UsersId",
                table: "Parkings");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Parkings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_UsersId",
                table: "Parkings",
                newName: "IX_Parkings_UserId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Histories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ParkingsId",
                table: "Histories",
                newName: "ParkingId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_UsersId",
                table: "Histories",
                newName: "IX_Histories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_ParkingsId",
                table: "Histories",
                newName: "IX_Histories_ParkingId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
