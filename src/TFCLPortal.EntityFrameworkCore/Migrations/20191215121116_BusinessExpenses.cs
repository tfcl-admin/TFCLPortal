using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class BusinessExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessExpense",
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
                    TeacherSalary = table.Column<decimal>(nullable: false),
                    OtherSalary = table.Column<decimal>(nullable: false),
                    Rent = table.Column<decimal>(nullable: false),
                    Utilities = table.Column<decimal>(nullable: false),
                    Entertainment = table.Column<decimal>(nullable: false),
                    RepairMaintenance = table.Column<decimal>(nullable: false),
                    Transportation = table.Column<decimal>(nullable: false),
                    OtherExpenses = table.Column<decimal>(nullable: false),
                    TotalMonthlyExpneses = table.Column<decimal>(nullable: false),
                    ProvisisonExpneses = table.Column<decimal>(nullable: false),
                    NetMonthlyBusinessExpense = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExposureDetailChild",
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
                    Fk_ExpoDetailID = table.Column<int>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    TypeOfFacilityTE = table.Column<string>(nullable: true),
                    LoanAmount = table.Column<decimal>(nullable: false),
                    OutstandingAmount = table.Column<decimal>(nullable: false),
                    MonthlyInstallmentPayment = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExposureDetailChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessExpense");

            migrationBuilder.DropTable(
                name: "ExposureDetailChild");
        }
    }
}
