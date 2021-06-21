using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class additionInHouseHold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel1",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel2",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel3",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue1",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue2",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue3",
                table: "HouseholdIncomeExpense",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel1",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel2",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel3",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue1",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue2",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue3",
                table: "HouseholdIncomeExpense");
        }
    }
}
