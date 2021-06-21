using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInDBdueToMCfeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "VehicleActualLTV",
                table: "LoanEligibilities");

            migrationBuilder.RenameColumn(
                name: "VehicleMaxFinancingAllowed",
                table: "LoanEligibilities",
                newName: "MaxAllowedLTVAllCollateral");

            migrationBuilder.RenameColumn(
                name: "VehicleLTVPercentage",
                table: "LoanEligibilities",
                newName: "AllCollateralMarketValue");

            migrationBuilder.RenameColumn(
                name: "VehicleCollateralValue",
                table: "LoanEligibilities",
                newName: "ActualLTVPercentageAllCollateral");

            migrationBuilder.AddColumn<int>(
                name: "NoOfBranchAccount",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "ExposureDetailChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedLtvPercentage",
                table: "CollateralVehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralVehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleAge",
                table: "CollateralVehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleAgeName",
                table: "CollateralVehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedLtvPercentage",
                table: "CollateralTDR",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankRating",
                table: "CollateralTDR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankRatingName",
                table: "CollateralTDR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralTDR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedLtvPercentage",
                table: "CollateralLandBuilding",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralLandBuilding",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedLtvPercentage",
                table: "CollateralGold",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralGold",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedLtvPercentage",
                table: "CollateralFranchise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralFranchise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AllCollateralMarketPrice",
                table: "CollateralDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxFinancingAllowedLtvAllCollaterals",
                table: "CollateralDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfBranchAccount",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "ExposureDetailChild");

            migrationBuilder.DropColumn(
                name: "AppliedLtvPercentage",
                table: "CollateralVehicle");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralVehicle");

            migrationBuilder.DropColumn(
                name: "VehicleAge",
                table: "CollateralVehicle");

            migrationBuilder.DropColumn(
                name: "VehicleAgeName",
                table: "CollateralVehicle");

            migrationBuilder.DropColumn(
                name: "AppliedLtvPercentage",
                table: "CollateralTDR");

            migrationBuilder.DropColumn(
                name: "BankRating",
                table: "CollateralTDR");

            migrationBuilder.DropColumn(
                name: "BankRatingName",
                table: "CollateralTDR");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralTDR");

            migrationBuilder.DropColumn(
                name: "AppliedLtvPercentage",
                table: "CollateralLandBuilding");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralLandBuilding");

            migrationBuilder.DropColumn(
                name: "AppliedLtvPercentage",
                table: "CollateralGold");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralGold");

            migrationBuilder.DropColumn(
                name: "AppliedLtvPercentage",
                table: "CollateralFranchise");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLTV",
                table: "CollateralFranchise");

            migrationBuilder.DropColumn(
                name: "AllCollateralMarketPrice",
                table: "CollateralDetail");

            migrationBuilder.DropColumn(
                name: "MaxFinancingAllowedLtvAllCollaterals",
                table: "CollateralDetail");

            migrationBuilder.RenameColumn(
                name: "MaxAllowedLTVAllCollateral",
                table: "LoanEligibilities",
                newName: "VehicleMaxFinancingAllowed");

            migrationBuilder.RenameColumn(
                name: "AllCollateralMarketValue",
                table: "LoanEligibilities",
                newName: "VehicleLTVPercentage");

            migrationBuilder.RenameColumn(
                name: "ActualLTVPercentageAllCollateral",
                table: "LoanEligibilities",
                newName: "VehicleCollateralValue");

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
                name: "VehicleActualLTV",
                table: "LoanEligibilities",
                nullable: true);
        }
    }
}
