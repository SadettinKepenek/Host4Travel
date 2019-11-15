using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class Modify_FK_PostCheckIn_PostApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_PostApplication",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCheckIn_PostApplication",
                table: "PostApplication",
                column: "PostApplicationId",
                principalTable: "PostCheckIn",
                principalColumn: "PostCheckInId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_PostApplication",
                table: "PostApplication");

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCheckIn_PostApplication",
                table: "PostCheckIn",
                column: "ApplicationId",
                principalTable: "PostApplication",
                principalColumn: "PostApplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
