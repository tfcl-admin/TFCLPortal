using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInBusinessPlanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanAmountRequired",
                table: "BusinessPlan",
                newName: "LoanAmountRecommended");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanAmountRecommended",
                table: "BusinessPlan",
                newName: "LoanAmountRequired");
        }
    }
}
