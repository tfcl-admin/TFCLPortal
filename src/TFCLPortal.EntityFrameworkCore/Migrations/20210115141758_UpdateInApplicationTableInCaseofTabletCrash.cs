using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInApplicationTableInCaseofTabletCrash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicSession",
                table: "Applicationz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FranchiserName",
                table: "Applicationz",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Applicationz",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Applicationz",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolCategory",
                table: "Applicationz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isFranchise",
                table: "Applicationz",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicSession",
                table: "Applicationz");

            migrationBuilder.DropColumn(
                name: "FranchiserName",
                table: "Applicationz");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Applicationz");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Applicationz");

            migrationBuilder.DropColumn(
                name: "SchoolCategory",
                table: "Applicationz");

            migrationBuilder.DropColumn(
                name: "isFranchise",
                table: "Applicationz");
        }
    }
}
