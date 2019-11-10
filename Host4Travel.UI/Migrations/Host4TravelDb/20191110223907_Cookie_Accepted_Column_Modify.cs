using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations.Host4TravelDb
{
    public partial class Cookie_Accepted_Column_Modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CookieAccepted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookieAccepted",
                table: "AspNetUsers");
        }
    }
}
