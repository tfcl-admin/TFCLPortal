using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatesForTDSLoanEligibilityAPi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TDSLoanEligibilities",
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
                    LoanAmountRequried = table.Column<string>(nullable: true),
                    LoanTenureRequested = table.Column<string>(nullable: true),
                    NuOfInstallmentPerYear = table.Column<string>(nullable: true),
                    Mark_Up = table.Column<string>(nullable: true),
                    MonthlyBusinessSale = table.Column<string>(nullable: true),
                    MonthlyBusinessSaleSharingPercentage = table.Column<string>(nullable: true),
                    MonthlyBusinessSaleConsidered = table.Column<string>(nullable: true),
                    MonthlyBusinessExpenses = table.Column<string>(nullable: true),
                    MonthlyBusinessExpensesSharingPercentage = table.Column<string>(nullable: true),
                    MonthlyBusinessExpensesConsidered = table.Column<string>(nullable: true),
                    MonthlyIncome = table.Column<string>(nullable: true),
                    OtherIncome = table.Column<string>(nullable: true),
                    GrossBusinessIncome = table.Column<string>(nullable: true),
                    MonthlyExposure = table.Column<string>(nullable: true),
                    NetBusinessIncome = table.Column<string>(nullable: true),
                    HouseholdExpenses = table.Column<string>(nullable: true),
                    MaxIncomeForTfclPayment = table.Column<string>(nullable: true),
                    TfclEmiPayment = table.Column<string>(nullable: true),
                    InstallmentRatio = table.Column<string>(nullable: true),
                    CollateralValue = table.Column<string>(nullable: true),
                    AllowedLtvPercentage = table.Column<string>(nullable: true),
                    MaxFinancingAllowedLTV = table.Column<string>(nullable: true),
                    ActualLtvPercentage = table.Column<string>(nullable: true),
                    LoanEligibilityStatusOnEMI = table.Column<string>(nullable: true),
                    LoanEligibilityStatusOnLTV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDSLoanEligibilities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDSLoanEligibilities");
        }
    }
}
