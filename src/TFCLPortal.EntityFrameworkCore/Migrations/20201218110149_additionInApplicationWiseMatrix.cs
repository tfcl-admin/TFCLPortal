using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class additionInApplicationWiseMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LTVForAgriculturalLand",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForCommercialBuilding",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForCommercialLand",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForFranchiseAgreement",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForGold",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForResidentialBuilding",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForResidentialLand",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForTDRratedA",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForTDRratedB",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleLessThanFiveYear",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleLessThanOneYear",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleMoreThanFiveYear",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinStudentEnrolled",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LTVForAgriculturalLand",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForCommercialBuilding",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForCommercialLand",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForFranchiseAgreement",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForGold",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForResidentialBuilding",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForResidentialLand",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForTDRratedA",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForTDRratedB",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleLessThanFiveYear",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleLessThanOneYear",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleMoreThanFiveYear",
                table: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropColumn(
                name: "MinStudentEnrolled",
                table: "ApplicationWiseDeviationVariable");
        }
    }
}
