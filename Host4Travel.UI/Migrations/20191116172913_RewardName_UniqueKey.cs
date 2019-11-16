using Microsoft.EntityFrameworkCore.Migrations;

namespace Host4Travel.UI.Migrations
{
    public partial class RewardName_UniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reward_RewardName",
                table: "Reward",
                column: "RewardName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reward_RewardName",
                table: "Reward");
        }
    }
}
