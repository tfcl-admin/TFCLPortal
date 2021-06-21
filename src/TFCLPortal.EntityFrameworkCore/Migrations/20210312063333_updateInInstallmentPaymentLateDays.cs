using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInInstallmentPaymentLateDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LateDays",
                table: "InstallmentPayment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LateDaysPenalty",
                table: "InstallmentPayment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isLateDaysApplied",
                table: "InstallmentPayment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LateDays",
                table: "InstallmentPayment");

            migrationBuilder.DropColumn(
                name: "LateDaysPenalty",
                table: "InstallmentPayment");

            migrationBuilder.DropColumn(
                name: "isLateDaysApplied",
                table: "InstallmentPayment");
        }
    }
}
