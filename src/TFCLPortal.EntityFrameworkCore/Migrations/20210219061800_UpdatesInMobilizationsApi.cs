using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdatesInMobilizationsApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantType",
                table: "MobilizationTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactSource",
                table: "MobilizationTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiName",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTenure",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlySalary",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolGoingDependants",
                table: "MobilizationTable",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantType",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "ContactSource",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "FiName",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "JobTenure",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "SchoolGoingDependants",
                table: "MobilizationTable");
        }
    }
}
