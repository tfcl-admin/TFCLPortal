using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateForBusinessExpenseApi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nConsideredBusinessExpense",
                table: "BusinessExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nGrandTotalBusinessExpense",
                table: "BusinessExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nMinConsideredPercentage",
                table: "BusinessExpense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nPercentageOfBeAgaintNETbI",
                table: "BusinessExpense",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nConsideredBusinessExpense",
                table: "BusinessExpense");

            migrationBuilder.DropColumn(
                name: "nGrandTotalBusinessExpense",
                table: "BusinessExpense");

            migrationBuilder.DropColumn(
                name: "nMinConsideredPercentage",
                table: "BusinessExpense");

            migrationBuilder.DropColumn(
                name: "nPercentageOfBeAgaintNETbI",
                table: "BusinessExpense");
        }
    }
}
