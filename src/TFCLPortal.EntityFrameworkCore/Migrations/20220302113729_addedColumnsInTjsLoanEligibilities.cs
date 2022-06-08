using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedColumnsInTjsLoanEligibilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActualLtvPercentage",
                table: "TJSLoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AllowedLtvPercentage",
                table: "TJSLoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollateralValue",
                table: "TJSLoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "TJSLoanEligibilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualLtvPercentage",
                table: "TJSLoanEligibilities");

            migrationBuilder.DropColumn(
                name: "AllowedLtvPercentage",
                table: "TJSLoanEligibilities");

            migrationBuilder.DropColumn(
                name: "CollateralValue",
                table: "TJSLoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "TJSLoanEligibilities");
        }
    }
}
