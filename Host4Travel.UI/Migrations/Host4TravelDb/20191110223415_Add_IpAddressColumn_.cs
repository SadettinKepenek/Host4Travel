using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations.Host4TravelDb
{
    public partial class Add_IpAddressColumn_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AspNetUsers",
                maxLength: 192,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 192,
                oldNullable: true);
        }
    }
}
