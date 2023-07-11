using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class added_LegalCharges_ColmnINscheduleTABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FedonLegalProcessingCharges",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalProcessingCharges",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FedonLegalProcessingCharges",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "LegalProcessingCharges",
                table: "Schedule");
        }
    }
}
