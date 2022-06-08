using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdatedAssetLiabilityAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrTotalCurrentAssets",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrTotalCurrentLiabilities",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalFixedAssets",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalLongTermLiabilities",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrAccountPayable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrAccountRecievable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrAdvanceReceived",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrCommittee",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrCommitteeLiabilities",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsCurrLoanPayableBanks",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrAccountPayable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrAccountRecievable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrAdvanceReceived",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrCommittee",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrCommitteeLiabilities",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyCurrLoanPayableBanks",
                table: "AssetLiabilityDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrTotalCurrentAssets",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "CurrTotalCurrentLiabilities",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "TotalFixedAssets",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "TotalLongTermLiabilities",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrAccountPayable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrAccountRecievable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrAdvanceReceived",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrCommittee",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrCommitteeLiabilities",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsCurrLoanPayableBanks",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrAccountPayable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrAccountRecievable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrAdvanceReceived",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrCommittee",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrCommitteeLiabilities",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyCurrLoanPayableBanks",
                table: "AssetLiabilityDetail");
        }
    }
}
