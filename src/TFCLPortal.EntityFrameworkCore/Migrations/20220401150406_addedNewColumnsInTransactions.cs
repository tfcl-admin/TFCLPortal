using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedNewColumnsInTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmountWords",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyBankId",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModeOfPayment",
                table: "Transaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountWords",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CompanyBankId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ModeOfPayment",
                table: "Transaction");
        }
    }
}
