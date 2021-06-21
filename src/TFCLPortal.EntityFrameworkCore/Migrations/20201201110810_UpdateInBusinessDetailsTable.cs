using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInBusinessDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessProfitConsidered",
                table: "School_Branch",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfPartnerInvestorDirector",
                table: "School_Branch",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalStaffFemale",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalStaffMale",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalStaffTotal",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "noOfElectricityConnections",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "noOfLandlineConnections",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "noOfWaterGasConnections",
                table: "School_Branch",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessProfitConsidered",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "NameOfPartnerInvestorDirector",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "TotalStaffFemale",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "TotalStaffMale",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "TotalStaffTotal",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "noOfElectricityConnections",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "noOfLandlineConnections",
                table: "School_Branch");

            migrationBuilder.DropColumn(
                name: "noOfWaterGasConnections",
                table: "School_Branch");
        }
    }
}
