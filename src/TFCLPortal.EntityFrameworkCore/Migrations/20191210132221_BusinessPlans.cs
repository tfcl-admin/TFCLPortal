using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class BusinessPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPlan",
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
                    BranchCode = table.Column<string>(nullable: true),
                    ApplicationNo = table.Column<string>(nullable: true),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    Purpose = table.Column<int>(nullable: false),
                    PEPs = table.Column<string>(nullable: true),
                    ClientExistInCelBel = table.Column<string>(nullable: true),
                    TotalInvestmentRequired = table.Column<string>(nullable: true),
                    AmountWorkingCapital = table.Column<string>(nullable: true),
                    AmountCapitalExpenditure = table.Column<string>(nullable: true),
                    ClientShare = table.Column<string>(nullable: true),
                    LoanAmountRequired = table.Column<string>(nullable: true),
                    LoanTenureRequested = table.Column<string>(nullable: true),
                    CollateralGiven = table.Column<string>(nullable: true),
                    PaymentFrequency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPlan");
        }
    }
}
