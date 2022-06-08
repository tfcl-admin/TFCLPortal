using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedColumnpublicintTurnArroundTimeMinsgetset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurnArroundTimeMins",
                table: "ScheduleTemp",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnArroundTimeMins",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnArroundTimeMins",
                table: "ScheduleTemp");

            migrationBuilder.DropColumn(
                name: "TurnArroundTimeMins",
                table: "Schedule");
        }
    }
}
