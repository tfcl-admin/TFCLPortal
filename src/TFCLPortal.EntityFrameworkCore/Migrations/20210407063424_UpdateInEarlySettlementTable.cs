using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInEarlySettlementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MarkupPayable",
                table: "EarlySettlement",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isAuthorized",
                table: "EarlySettlement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rejectionReason",
                table: "EarlySettlement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkupPayable",
                table: "EarlySettlement");

            migrationBuilder.DropColumn(
                name: "isAuthorized",
                table: "EarlySettlement");

            migrationBuilder.DropColumn(
                name: "rejectionReason",
                table: "EarlySettlement");
        }
    }
}
