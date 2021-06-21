using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInAssetLiabilityAddedDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "qtyOtherAssets",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetVehicle",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetStockInHand",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetSolar",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetLandBuliding",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetGirviAmount",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetGeneratorUps",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetFurnitureFixture",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetFranchiseFee",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetEquipment",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetComputers",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetCommittee",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetCashInHandAtBank",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetAirConditioners",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "qtyAssetAccountReceivable",
                table: "AssetLiabilityDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "detailsAccountPayable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsAdvanceReceived",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCommittee",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsLoanPayableBank",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsOtherLiabilities",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsStudentSecurityDeposit",
                table: "AssetLiabilityDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detailsAccountPayable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsAdvanceReceived",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCommittee",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsLoanPayableBank",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsOtherLiabilities",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsStudentSecurityDeposit",
                table: "AssetLiabilityDetail");

            migrationBuilder.AlterColumn<int>(
                name: "qtyOtherAssets",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetVehicle",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetStockInHand",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetSolar",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetLandBuliding",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetGirviAmount",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetGeneratorUps",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetFurnitureFixture",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetFranchiseFee",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetEquipment",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetComputers",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetCommittee",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetCashInHandAtBank",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetAirConditioners",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "qtyAssetAccountReceivable",
                table: "AssetLiabilityDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
