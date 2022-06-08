using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedMarkupPrincipalPaidColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isMarkupPaid",
                table: "ScheduleInstallment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPrincipalPaid",
                table: "ScheduleInstallment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMarkupPaid",
                table: "ScheduleInstallment");

            migrationBuilder.DropColumn(
                name: "isPrincipalPaid",
                table: "ScheduleInstallment");
        }
    }
}
