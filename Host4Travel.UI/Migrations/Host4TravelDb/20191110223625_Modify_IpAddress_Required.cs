using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations.Host4TravelDb
{
    public partial class Modify_IpAddress_Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AspNetUsers",
                maxLength: 192,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(192)",
                oldMaxLength: 192,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AspNetUsers",
                type: "nvarchar(192)",
                maxLength: 192,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 192);
        }
    }
}
