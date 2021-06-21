using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class HouseholdIncomesExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseholdIncomeExpense",
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
                    HouseholdIncome = table.Column<string>(nullable: true),
                    HouseRent = table.Column<string>(nullable: true),
                    Food = table.Column<string>(nullable: true),
                    Clothing = table.Column<string>(nullable: true),
                    Medical = table.Column<string>(nullable: true),
                    Utilities = table.Column<string>(nullable: true),
                    Educational = table.Column<string>(nullable: true),
                    LoanInstallment = table.Column<string>(nullable: true),
                    CommitteeInstallment = table.Column<string>(nullable: true),
                    OtherHouseholdExpenses = table.Column<string>(nullable: true),
                    ProvisionalHouseholdExpenses = table.Column<string>(nullable: true),
                    NetTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdIncomeExpense", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseholdIncomeExpense");
        }
    }
}
