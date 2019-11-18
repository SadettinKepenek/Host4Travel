using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class Modify_Relations_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_PostApplication_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostApplication_PostCheckIn",
                table: "PostCheckIn",
                column: "ApplicationId",
                principalTable: "PostApplication",
                principalColumn: "PostApplicationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostApplication_PostCheckIn",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCheckIn_PostApplication_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId",
                principalTable: "PostApplication",
                principalColumn: "PostApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
