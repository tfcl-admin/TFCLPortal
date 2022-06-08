using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AddedColumnSpouseFamilyOtherIncomeInSF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "spouseFamilyOtherIncome",
                table: "SchoolFinancial",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "spouseFamilyOtherIncome",
                table: "SchoolFinancial");
        }
    }
}
