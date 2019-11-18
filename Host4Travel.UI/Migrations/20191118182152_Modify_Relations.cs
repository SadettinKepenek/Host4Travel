using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class Modify_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_PostApplication",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "PostCheckIn",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_PostId",
                table: "PostCheckIn",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostApplication_PostId",
                table: "PostApplication",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostApplication_Post",
                table: "PostApplication",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCheckIn_PostApplication_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId",
                principalTable: "PostApplication",
                principalColumn: "PostApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCheckIn_Post",
                table: "PostCheckIn",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostApplication_Post",
                table: "PostApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_PostApplication_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCheckIn_Post",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostCheckIn_PostId",
                table: "PostCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_PostApplication_PostId",
                table: "PostApplication");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostCheckIn");

            migrationBuilder.CreateIndex(
                name: "IX_PostCheckIn_ApplicationId",
                table: "PostCheckIn",
                column: "ApplicationId",
                unique: true);

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
