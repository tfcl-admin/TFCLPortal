using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class additionInDeviationVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LTVForAgriculturalLand",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForCommercialBuilding",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForCommercialLand",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForFranchiseAgreement",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForGold",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForResidentialBuilding",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForResidentialLand",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForTDRratedA",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForTDRratedB",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleLessThanFiveYear",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleLessThanOneYear",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTVForVehicleMoreThanFiveYear",
                table: "DeviationMatrix",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinStudentEnrolled",
                table: "DeviationMatrix",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LTVForAgriculturalLand",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForCommercialBuilding",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForCommercialLand",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForFranchiseAgreement",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForGold",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForResidentialBuilding",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForResidentialLand",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForTDRratedA",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForTDRratedB",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleLessThanFiveYear",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleLessThanOneYear",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "LTVForVehicleMoreThanFiveYear",
                table: "DeviationMatrix");

            migrationBuilder.DropColumn(
                name: "MinStudentEnrolled",
                table: "DeviationMatrix");
        }
    }
}
