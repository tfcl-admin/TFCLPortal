using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedProcessingChargesColumnsInScheduleTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FEDonProcessingCharges",
                table: "ScheduleTemp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetDisbursmentAmount",
                table: "ScheduleTemp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessingCharges",
                table: "ScheduleTemp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FEDonProcessingCharges",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetDisbursmentAmount",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessingCharges",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FEDonProcessingCharges",
                table: "ScheduleTemp");

            migrationBuilder.DropColumn(
                name: "NetDisbursmentAmount",
                table: "ScheduleTemp");

            migrationBuilder.DropColumn(
                name: "ProcessingCharges",
                table: "ScheduleTemp");

            migrationBuilder.DropColumn(
                name: "FEDonProcessingCharges",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "NetDisbursmentAmount",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ProcessingCharges",
                table: "Schedule");
        }
    }
}
