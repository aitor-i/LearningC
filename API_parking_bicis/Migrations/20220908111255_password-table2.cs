using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_parking_bicis.Migrations
{
    public partial class passwordtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passwords_UsersId",
                table: "Passwords");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UsersId",
                table: "Passwords",
                column: "UsersId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passwords_UsersId",
                table: "Passwords");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UsersId",
                table: "Passwords",
                column: "UsersId");
        }
    }
}
