using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class Add_relation_applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "PostDiscussion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostDiscussion_OwnerId1",
                table: "PostDiscussion",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostDiscussion_AspNetUsers_OwnerId1",
                table: "PostDiscussion",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostDiscussion_AspNetUsers_OwnerId1",
                table: "PostDiscussion");

            migrationBuilder.DropIndex(
                name: "IX_PostDiscussion_OwnerId1",
                table: "PostDiscussion");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "PostDiscussion");
        }
    }
}
