using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedSchoolFinancialApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolFinancial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false),
                    PreviousYear = table.Column<string>(nullable: true),
                    NoOfClassrooms = table.Column<int>(nullable: false),
                    NoOfStudents = table.Column<int>(nullable: false),
                    NoOfTeachingStaff = table.Column<int>(nullable: false),
                    NoOfNonTeachingStaff = table.Column<int>(nullable: false),
                    AvgMonthlyFee = table.Column<string>(nullable: true),
                    TotalRevenue = table.Column<string>(nullable: true),
                    TotalExpensesFromSalary = table.Column<string>(nullable: true),
                    TotalExpensesFromRentMortgage = table.Column<string>(nullable: true),
                    TotalExpensesFromDebt = table.Column<string>(nullable: true),
                    AllOtherExpenses = table.Column<string>(nullable: true),
                    TotalProfit = table.Column<string>(nullable: true),
                    ProfitMargin = table.Column<string>(nullable: true),
                    TotalAsset = table.Column<string>(nullable: true),
                    CurrentAsset = table.Column<string>(nullable: true),
                    TotalLiabilities = table.Column<string>(nullable: true),
                    CurrentLiabilities = table.Column<string>(nullable: true),
                    WorkingCapital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFinancial", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolFinancial");
        }
    }
}
