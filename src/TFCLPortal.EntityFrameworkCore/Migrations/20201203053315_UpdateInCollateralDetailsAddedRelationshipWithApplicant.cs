using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInCollateralDetailsAddedRelationshipWithApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelationWithApplicant",
                table: "CollateralVehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationWithApplicant",
                table: "CollateralTDR",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationWithApplicant",
                table: "CollateralLandBuilding",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationWithApplicant",
                table: "CollateralGold",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationWithApplicant",
                table: "CollateralFranchise",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationWithApplicant",
                table: "CollateralVehicle");

            migrationBuilder.DropColumn(
                name: "RelationWithApplicant",
                table: "CollateralTDR");

            migrationBuilder.DropColumn(
                name: "RelationWithApplicant",
                table: "CollateralLandBuilding");

            migrationBuilder.DropColumn(
                name: "RelationWithApplicant",
                table: "CollateralGold");

            migrationBuilder.DropColumn(
                name: "RelationWithApplicant",
                table: "CollateralFranchise");
        }
    }
}
