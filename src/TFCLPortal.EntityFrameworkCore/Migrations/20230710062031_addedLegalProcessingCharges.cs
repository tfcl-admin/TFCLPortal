using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedLegalProcessingCharges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxLegalProcessingCharges",
                table: "PaymentChargesDeviationMatrix",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinLegalProcessingCharges",
                table: "PaymentChargesDeviationMatrix",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxLegalProcessingCharges",
                table: "PaymentChargesDeviationMatrix");

            migrationBuilder.DropColumn(
                name: "MinLegalProcessingCharges",
                table: "PaymentChargesDeviationMatrix");
        }
    }
}
