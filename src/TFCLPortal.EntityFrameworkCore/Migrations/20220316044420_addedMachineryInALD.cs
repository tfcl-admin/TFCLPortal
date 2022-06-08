using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedMachineryInALD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "detailsMachinery",
                table: "AssetLiabilityDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qtyMachinery",
                table: "AssetLiabilityDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detailsMachinery",
                table: "AssetLiabilityDetail");

            migrationBuilder.DropColumn(
                name: "qtyMachinery",
                table: "AssetLiabilityDetail");
        }
    }
}
