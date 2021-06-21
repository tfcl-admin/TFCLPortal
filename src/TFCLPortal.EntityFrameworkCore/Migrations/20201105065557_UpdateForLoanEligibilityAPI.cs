using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateForLoanEligibilityAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademySharingPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssociatedSharingPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsideredAmountHHE",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsideredNonAssociatedIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsideredSnAExpenses",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FranchiseActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FranchiseCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FranchiseLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FranchiseMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoldActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoldCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoldLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoldMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrossIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanEligibilityStatusOnEMI",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoanEligibilityStatusOnLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinConsideredPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinConsideredPercentageOfHHE",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyAcademyExpenses",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyAcademyFeeIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyExposure",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyHouseHoldExpense",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlySchoolExpenses",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlySchoolFeeIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetAssociatedIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetIncomeBeforeHHexp",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetNonAssociatedIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonAssociatedMaxConsideredPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonAssociatedSharingPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageOfHHEAgainstNetBusinessIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageOfNAIAgainstTotalSchRevenue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageSAExpenseAgainstSAIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolSharingPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TDRActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TDRCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TDRLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TDRMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalAssociatedIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalNonAssociatedIncome",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalSchoolnAcademyExpenses",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalSchoolnAssociatedIncomeBeforeExpenses",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalSchoolnAssociatedNetExpense",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleActualLTV",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleCollateralValue",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleLTVPercentage",
                table: "LoanEligibilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleMaxFinancingAllowed",
                table: "LoanEligibilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademySharingPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "AssociatedSharingPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "BuildingActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "BuildingCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "BuildingLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "BuildingMaxFinancingAllowed",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "ConsideredAmountHHE",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "ConsideredNonAssociatedIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "ConsideredSnAExpenses",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "FranchiseActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "FranchiseCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "FranchiseLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "FranchiseMaxFinancingAllowed",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "GoldActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "GoldCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "GoldLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "GoldMaxFinancingAllowed",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "GrossIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LandActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LandCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LandLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LandMaxFinancingAllowed",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LoanEligibilityStatusOnEMI",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "LoanEligibilityStatusOnLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MinConsideredPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MinConsideredPercentageOfHHE",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlyAcademyExpenses",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlyAcademyFeeIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlyExposure",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlyHouseHoldExpense",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlySchoolExpenses",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "MonthlySchoolFeeIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "NetAssociatedIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "NetIncomeBeforeHHexp",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "NetNonAssociatedIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "NonAssociatedMaxConsideredPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "NonAssociatedSharingPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "PercentageOfHHEAgainstNetBusinessIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "PercentageOfNAIAgainstTotalSchRevenue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "PercentageSAExpenseAgainstSAIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "SchoolSharingPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TDRActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TDRCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TDRLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TDRMaxFinancingAllowed",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TotalAssociatedIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TotalNonAssociatedIncome",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TotalSchoolnAcademyExpenses",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TotalSchoolnAssociatedIncomeBeforeExpenses",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "TotalSchoolnAssociatedNetExpense",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "VehicleActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "VehicleCollateralValue",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "VehicleLTVPercentage",
                table: "LoanEligibilities");

            migrationBuilder.DropColumn(
                name: "VehicleMaxFinancingAllowed",
                table: "LoanEligibilities");
        }
    }
}
