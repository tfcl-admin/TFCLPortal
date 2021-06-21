using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatesInHouseHoldApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseHoldTransportation",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyEIfee",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyQarifee",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyTuitionfee",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherEducationalExpenses",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VanTransportationOfDependents",
                table: "HouseholdIncomeExpense",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseHoldTransportation",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "MonthlyEIfee",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "MonthlyQarifee",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "MonthlyTuitionfee",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "OtherEducationalExpenses",
                table: "HouseholdIncomeExpense");

            migrationBuilder.DropColumn(
                name: "VanTransportationOfDependents",
                table: "HouseholdIncomeExpense");
        }
    }
}
