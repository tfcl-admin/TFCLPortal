using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class PostDisbursementFormDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostDisbursementForm",
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
                    FileMonthlyIncome = table.Column<string>(nullable: true),
                    FileNetBusinessIncome = table.Column<string>(nullable: true),
                    FileIncomeAfterHHexp = table.Column<string>(nullable: true),
                    FileCollateral = table.Column<string>(nullable: true),
                    GuarantorBusinessCondition = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    LoanAmountUtilization = table.Column<string>(nullable: true),
                    CurrentMonthlyIncome = table.Column<string>(nullable: true),
                    CurrentNetBusinessIncome = table.Column<string>(nullable: true),
                    CurrentIncomeAfterHHexp = table.Column<string>(nullable: true),
                    CurrentCollateral = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDisbursementForm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostDisbursementForm");
        }
    }
}
