using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatesForTDSBusinessExpenseAPi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TDSBusinessExpense",
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
                    NetMonthlyBusinessExpense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDSBusinessExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TDSBusinessExpenseChild",
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
                    Fk_TDSBusinessExpenseid = table.Column<int>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    TotalSalary = table.Column<string>(nullable: true),
                    Purchases = table.Column<string>(nullable: true),
                    StaffSalary = table.Column<string>(nullable: true),
                    RentAmount = table.Column<string>(nullable: true),
                    Utilities = table.Column<string>(nullable: true),
                    Entertainment = table.Column<string>(nullable: true),
                    RepairMaintenance = table.Column<string>(nullable: true),
                    Transportation = table.Column<string>(nullable: true),
                    Carriage = table.Column<string>(nullable: true),
                    Committee = table.Column<string>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    Internet = table.Column<string>(nullable: true),
                    OtherExpenseLabelOne = table.Column<string>(nullable: true),
                    OtherExpenseValueOne = table.Column<string>(nullable: true),
                    OtherExpenseLabelTwo = table.Column<string>(nullable: true),
                    OtherExpenseValueTwo = table.Column<string>(nullable: true),
                    OtherExpenseLabelThree = table.Column<string>(nullable: true),
                    OtherExpenseValueThree = table.Column<string>(nullable: true),
                    TotalMonthlyExpenses = table.Column<string>(nullable: true),
                    ProvisionOfExpenses = table.Column<string>(nullable: true),
                    AmountOfProvision = table.Column<string>(nullable: true),
                    MonthlyBusinessExpenses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDSBusinessExpenseChild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TDSBusinessExpenseGrandChild",
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
                    Fk_TDSBusinessExpenseChildid = table.Column<int>(nullable: false),
                    EmployerName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDSBusinessExpenseGrandChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDSBusinessExpense");

            migrationBuilder.DropTable(
                name: "TDSBusinessExpenseChild");

            migrationBuilder.DropTable(
                name: "TDSBusinessExpenseGrandChild");
        }
    }
}
