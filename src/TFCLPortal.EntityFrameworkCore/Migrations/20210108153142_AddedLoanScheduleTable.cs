using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AddedLoanScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanSchedule",
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
                    ScheduleNo = table.Column<string>(nullable: true),
                    RevisionNo = table.Column<string>(nullable: true),
                    RevisionDate = table.Column<DateTime>(nullable: false),
                    ScheduleType = table.Column<string>(nullable: true),
                    DisbursmentDate = table.Column<DateTime>(nullable: false),
                    LoanStartDate = table.Column<DateTime>(nullable: false),
                    LastInstallmentDate = table.Column<DateTime>(nullable: false),
                    GraceDays = table.Column<int>(nullable: false),
                    IRR = table.Column<decimal>(nullable: false),
                    InstallmentAmount = table.Column<decimal>(nullable: false),
                    YearlyMarkup = table.Column<decimal>(nullable: false),
                    PerDayMarkup = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanSchedule", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanSchedule");
        }
    }
}
