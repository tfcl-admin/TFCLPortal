using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatedALDandLEforTJS_Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreciousItems",
                table: "AssetLiabilityDetail",
                newName: "qtyProvidentFund");

            migrationBuilder.AddColumn<string>(
                name: "detailsPreciousItems",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "detailsProvidentFund",
                table: "AssetLiabilityDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detailsPreciousItems",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "detailsProvidentFund",
                table: "AssetLiabilityDetail");

            migrationBuilder.RenameColumn(
                name: "qtyProvidentFund",
                table: "AssetLiabilityDetail",
                newName: "PreciousItems");
        }
    }
}
