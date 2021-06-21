using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateForBankAccountAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AccountMaintained",
                table: "BankAccountDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisMonth",
                table: "BankAccountDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccountChildDetail",
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
                    Fk_BankAccountDetail = table.Column<int>(nullable: false),
                    MonthName = table.Column<string>(nullable: true),
                    LowestBalanceDate1 = table.Column<DateTime>(nullable: true),
                    LowestBalance1 = table.Column<string>(nullable: true),
                    LowestBalanceDate2 = table.Column<DateTime>(nullable: true),
                    LowestBalance2 = table.Column<string>(nullable: true),
                    LowestBalanceDate3 = table.Column<DateTime>(nullable: true),
                    LowestBalance3 = table.Column<string>(nullable: true),
                    avgLowestBalance = table.Column<string>(nullable: true),
                    HighestBalanceDate1 = table.Column<DateTime>(nullable: true),
                    HighestBalance1 = table.Column<string>(nullable: true),
                    HighestBalanceDate2 = table.Column<DateTime>(nullable: true),
                    HighestBalance2 = table.Column<string>(nullable: true),
                    HighestBalanceDate3 = table.Column<DateTime>(nullable: true),
                    HighestBalance3 = table.Column<string>(nullable: true),
                    avgHighestBalance = table.Column<string>(nullable: true),
                    OverallAvgBalance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountChildDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountChildDetail");

            migrationBuilder.DropColumn(
                name: "AccountMaintained",
                table: "BankAccountDetail");

            migrationBuilder.DropColumn(
                name: "AnalysisMonth",
                table: "BankAccountDetail");
        }
    }
}
