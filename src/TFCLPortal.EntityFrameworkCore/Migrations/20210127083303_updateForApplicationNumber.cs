using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateForApplicationNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationNumber",
                table: "TaleemSchoolSarmaya",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationNumber",
                table: "TaleemSchoolAsasah",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationNumber",
                table: "TaleemSchoolSarmaya");

            migrationBuilder.DropColumn(
                name: "ApplicationNumber",
                table: "TaleemSchoolAsasah");
        }
    }
}
