using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatesInDeviationMatrixVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreshClientLoanStatus",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "RepeatClientLoanStatus",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "LoanAmount",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LoanTenure",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "NoOfInstallments",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "markup",
                table: "DeviationMatrix");

            migrationBuilder.AddColumn<string>(
                name: "LoanAmount",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanTenure",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfInstallments",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanAmount",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LoanTenure",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "NoOfInstallments",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.AddColumn<string>(
                name: "FreshClientLoanStatus",
                table: "ProductDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepeatClientLoanStatus",
                table: "ProductDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanAmount",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanTenure",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfInstallments",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "markup",
                table: "DeviationMatrix",
                nullable: true);
        }
    }
}
