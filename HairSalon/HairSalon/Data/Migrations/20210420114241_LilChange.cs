using Microsoft.EntityFrameworkCore.Migrations;

namespace HairSalon.Data.Migrations
{
    public partial class LilChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClientId",
                table: "Sessions",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Clients_ClientId",
                table: "Sessions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Clients_ClientId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ClientId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Sessions");
        }
    }
}
