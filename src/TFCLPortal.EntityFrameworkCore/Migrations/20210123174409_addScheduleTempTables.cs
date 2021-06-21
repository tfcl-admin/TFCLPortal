using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addScheduleTempTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleInstallmentTemp",
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
                    FK_ScheduleId = table.Column<int>(nullable: false),
                    InstNumber = table.Column<string>(nullable: true),
                    BalInst = table.Column<string>(nullable: true),
                    InstallmentDueDate = table.Column<string>(nullable: true),
                    OsPrincipal_op = table.Column<string>(nullable: true),
                    AdditionalTranche = table.Column<string>(nullable: true),
                    OsPrincipal_Opening = table.Column<string>(nullable: true),
                    markup = table.Column<string>(nullable: true),
                    principal = table.Column<string>(nullable: true),
                    installmentAmount = table.Column<string>(nullable: true),
                    OsPrincipal_Closing = table.Column<string>(nullable: true),
                    isPaid = table.Column<bool>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleInstallmentTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTemp",
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
                    ClientId = table.Column<string>(nullable: true),
                    ScheduleType = table.Column<string>(nullable: true),
                    LoanAmount = table.Column<string>(nullable: true),
                    Tenure = table.Column<string>(nullable: true),
                    Markup = table.Column<string>(nullable: true),
                    DisbursmentDate = table.Column<string>(nullable: true),
                    GraceDays = table.Column<string>(nullable: true),
                    Deferment = table.Column<string>(nullable: true),
                    AccountTitle = table.Column<string>(nullable: true),
                    RepaymentACnumber = table.Column<string>(nullable: true),
                    BankBranchName = table.Column<string>(nullable: true),
                    TFCL_Branch = table.Column<string>(nullable: true),
                    BranchManager = table.Column<string>(nullable: true),
                    SDE = table.Column<string>(nullable: true),
                    DeffermentStartDate = table.Column<string>(nullable: true),
                    DeffermentEndDate = table.Column<string>(nullable: true),
                    IRR = table.Column<string>(nullable: true),
                    Installment = table.Column<string>(nullable: true),
                    LoanStartDate = table.Column<string>(nullable: true),
                    LastInstallmentDate = table.Column<string>(nullable: true),
                    YearlyMarkup = table.Column<string>(nullable: true),
                    PerDayMarkup = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    isAuthorizedByBM = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTemp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleInstallmentTemp");

            migrationBuilder.DropTable(
                name: "ScheduleTemp");
        }
    }
}
