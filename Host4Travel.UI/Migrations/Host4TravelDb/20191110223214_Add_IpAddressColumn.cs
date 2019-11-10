using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations.Host4TravelDb
{
    public partial class Add_IpAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "AspNetUsers");
        }
    }
}
