using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedColumnsInED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentTotalAmount",
                table: "ExposureDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentTotalInstallmentpayment",
                table: "ExposureDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongtermInstallmentpayment",
                table: "ExposureDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongtermTotalAmount",
                table: "ExposureDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTotalAmount",
                table: "ExposureDetail");

            migrationBuilder.DropColumn(
                name: "CurrentTotalInstallmentpayment",
                table: "ExposureDetail");

            migrationBuilder.DropColumn(
                name: "LongtermInstallmentpayment",
                table: "ExposureDetail");

            migrationBuilder.DropColumn(
                name: "LongtermTotalAmount",
                table: "ExposureDetail");
        }
    }
}
