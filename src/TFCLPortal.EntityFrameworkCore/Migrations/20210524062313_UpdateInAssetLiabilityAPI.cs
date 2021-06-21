using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInAssetLiabilityAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountRecievable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreciousItems",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyAccountRecievable",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyPreciousItems",
                table: "AssetLiabilityDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRecievable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "PreciousItems",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyAccountRecievable",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyPreciousItems",
                table: "AssetLiabilityDetail");
        }
    }
}
