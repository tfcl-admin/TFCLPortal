using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedNewColumnInMobAndApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilizationRecordId",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilizationRecordId",
                table: "Applicationz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilizationRecordId",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "MobilizationRecordId",
                table: "Applicationz");
        }
    }
}
