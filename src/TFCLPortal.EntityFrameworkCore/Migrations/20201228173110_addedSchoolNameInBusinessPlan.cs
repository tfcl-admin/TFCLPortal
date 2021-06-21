using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedSchoolNameInBusinessPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "BusinessPlan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isAssociatedIncome",
                table: "AssociatedIncomeChild",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "BusinessPlan");

            migrationBuilder.DropColumn(
                name: "isAssociatedIncome",
                table: "AssociatedIncomeChild");
        }
    }
}
