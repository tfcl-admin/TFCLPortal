using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AdditionForSalesDetailsAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesDetail",
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
                    grandTotalSalesToBeConsidered = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetailChild",
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
                    Fk_SalesDetailId = table.Column<int>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    AnalysisMonth = table.Column<DateTime>(nullable: false),
                    Month1 = table.Column<DateTime>(nullable: true),
                    Month1Sales = table.Column<string>(nullable: true),
                    Month2 = table.Column<DateTime>(nullable: true),
                    Month2Sales = table.Column<string>(nullable: true),
                    Month3 = table.Column<DateTime>(nullable: true),
                    Month3Sales = table.Column<string>(nullable: true),
                    Month4 = table.Column<DateTime>(nullable: true),
                    Month4Sales = table.Column<string>(nullable: true),
                    Month5 = table.Column<DateTime>(nullable: true),
                    Month5Sales = table.Column<string>(nullable: true),
                    Month6 = table.Column<DateTime>(nullable: true),
                    Month6Sales = table.Column<string>(nullable: true),
                    Month7 = table.Column<DateTime>(nullable: true),
                    Month7Sales = table.Column<string>(nullable: true),
                    Month8 = table.Column<DateTime>(nullable: true),
                    Month8Sales = table.Column<string>(nullable: true),
                    Month9 = table.Column<DateTime>(nullable: true),
                    Month9Sales = table.Column<string>(nullable: true),
                    Month10 = table.Column<DateTime>(nullable: true),
                    Month10Sales = table.Column<string>(nullable: true),
                    Month11 = table.Column<DateTime>(nullable: true),
                    Month11Sales = table.Column<string>(nullable: true),
                    Month12 = table.Column<DateTime>(nullable: true),
                    Month12Sales = table.Column<string>(nullable: true),
                    PerMonthAvgSeasonalSale = table.Column<string>(nullable: true),
                    TotalMonthlyProductWiseSale = table.Column<string>(nullable: true),
                    DailySalesAmount = table.Column<string>(nullable: true),
                    NoOfWorkingDays = table.Column<string>(nullable: true),
                    WeeklySales = table.Column<string>(nullable: true),
                    MonthlySales = table.Column<string>(nullable: true),
                    SalesToBeConsideredThreeLower = table.Column<string>(nullable: true),
                    IncomeEfficiency = table.Column<string>(nullable: true),
                    SalesToBeConsidered = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetailChild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetailGrandChild",
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
                    Fk_SalesDetailChildId = table.Column<int>(nullable: false),
                    SrNo = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    PerUnitSalePrice = table.Column<string>(nullable: true),
                    MonthlySaleUnit = table.Column<string>(nullable: true),
                    TotalSale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetailGrandChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetail");

            migrationBuilder.DropTable(
                name: "SalesDetailChild");

            migrationBuilder.DropTable(
                name: "SalesDetailGrandChild");
        }
    }
}
