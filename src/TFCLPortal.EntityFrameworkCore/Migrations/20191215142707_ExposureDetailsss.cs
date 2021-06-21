using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class ExposureDetailsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyInstallmentPayment",
                table: "ExposureDetail",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInstallmentpayment",
                table: "ExposureDetail",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyInstallmentPayment",
                table: "ExposureDetail");

            migrationBuilder.DropColumn(
                name: "TotalInstallmentpayment",
                table: "ExposureDetail");
        }
    }
}
