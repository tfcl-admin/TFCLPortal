using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedLoanStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanStatus",
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
                    Tenure = table.Column<int>(nullable: false),
                    LastLateDays = table.Column<int>(nullable: false),
                    LastInstallmentDueDate = table.Column<DateTime>(nullable: false),
                    LastInstallmentNo = table.Column<string>(nullable: true),
                    LastInstallmentPrincipal = table.Column<decimal>(nullable: false),
                    LastInstallmentMarkup = table.Column<decimal>(nullable: false),
                    LastInstallmentAmount = table.Column<decimal>(nullable: false),
                    LastPaidDate = table.Column<DateTime>(nullable: false),
                    LastPaidAmount = table.Column<decimal>(nullable: false),
                    LastExcessShort = table.Column<decimal>(nullable: false),
                    LastOutstandingPrincipal = table.Column<decimal>(nullable: false),
                    CurrentLateDays = table.Column<int>(nullable: false),
                    CurrentInstallmentNo = table.Column<string>(nullable: true),
                    CurrentInstallmentDueDate = table.Column<DateTime>(nullable: false),
                    CurrentInstallmentPrincipal = table.Column<decimal>(nullable: false),
                    CurrentInstallmentMarkup = table.Column<decimal>(nullable: false),
                    CurrentInstallmentAmount = table.Column<decimal>(nullable: false),
                    CurrentPaidAmount = table.Column<decimal>(nullable: false),
                    CurrentExcessShort = table.Column<decimal>(nullable: false),
                    CurrentOutstandingPrincipal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanStatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanStatus");
        }
    }
}
