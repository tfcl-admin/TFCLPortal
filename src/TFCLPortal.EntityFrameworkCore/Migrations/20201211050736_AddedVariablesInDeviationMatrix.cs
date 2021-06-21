using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AddedVariablesInDeviationMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
