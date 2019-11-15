using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class Modify_FK_PostRating_PostApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRating_PostApplication",
                table: "PostRating");

            migrationBuilder.DropIndex(
                name: "IX_PostRating_ApplicationId",
                table: "PostRating");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRating_PostApplication",
                table: "PostApplication",
                column: "PostApplicationId",
                principalTable: "PostRating",
                principalColumn: "PostRatingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRating_PostApplication",
                table: "PostApplication");

            migrationBuilder.CreateIndex(
                name: "IX_PostRating_ApplicationId",
                table: "PostRating",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRating_PostApplication",
                table: "PostRating",
                column: "ApplicationId",
                principalTable: "PostApplication",
                principalColumn: "PostApplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
