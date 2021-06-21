using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateForAssociatedIncomeApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssociatedIncome",
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
                    isAssociatedIncome = table.Column<string>(nullable: true),
                    TotalAssociatedIncome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatedIncome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociatedIncomeChild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Fk_AssociatedIncome = table.Column<int>(nullable: false),
                    OtherAssociatedIncome = table.Column<int>(nullable: true),
                    OtherAssociatedIncomeOthers = table.Column<string>(nullable: true),
                    DocumentProof = table.Column<bool>(nullable: true),
                    NumberOfStudents = table.Column<string>(nullable: true),
                    AvgCharges = table.Column<string>(nullable: true),
                    YearlyRevenue = table.Column<string>(nullable: true),
                    MonthlyRevenue = table.Column<string>(nullable: true),
                    OtherAssociatedIncomeAmount = table.Column<string>(nullable: true),
                    ConsideredPercentage = table.Column<string>(nullable: true),
                    ConsideredAmount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatedIncomeChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociatedIncome");

            migrationBuilder.DropTable(
                name: "AssociatedIncomeChild");
        }
    }
}
