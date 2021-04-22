using Microsoft.EntityFrameworkCore.Migrations;

namespace HairSalon.Data.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ServiceId",
                table: "Sessions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Service_ServiceId",
                table: "Sessions",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Service_ServiceId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ServiceId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Sessions");
        }
    }
}
