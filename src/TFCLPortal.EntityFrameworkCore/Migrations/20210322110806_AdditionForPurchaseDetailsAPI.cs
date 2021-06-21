using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AdditionForPurchaseDetailsAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
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
                    grandTotalPurchaseToBeConsidered = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailChild",
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
                    Fk_PurchaseDetailId = table.Column<int>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    AnalysisMonth = table.Column<DateTime>(nullable: false),
                    Month1 = table.Column<DateTime>(nullable: true),
                    Month1Purchases = table.Column<string>(nullable: true),
                    Month2 = table.Column<DateTime>(nullable: true),
                    Month2Purchases = table.Column<string>(nullable: true),
                    Month3 = table.Column<DateTime>(nullable: true),
                    Month3Purchases = table.Column<string>(nullable: true),
                    Month4 = table.Column<DateTime>(nullable: true),
                    Month4Purchases = table.Column<string>(nullable: true),
                    Month5 = table.Column<DateTime>(nullable: true),
                    Month5Purchases = table.Column<string>(nullable: true),
                    Month6 = table.Column<DateTime>(nullable: true),
                    Month6Purchases = table.Column<string>(nullable: true),
                    Month7 = table.Column<DateTime>(nullable: true),
                    Month7Purchases = table.Column<string>(nullable: true),
                    Month8 = table.Column<DateTime>(nullable: true),
                    Month8Purchases = table.Column<string>(nullable: true),
                    Month9 = table.Column<DateTime>(nullable: true),
                    Month9Purchases = table.Column<string>(nullable: true),
                    Month10 = table.Column<DateTime>(nullable: true),
                    Month10Purchases = table.Column<string>(nullable: true),
                    Month11 = table.Column<DateTime>(nullable: true),
                    Month11Purchases = table.Column<string>(nullable: true),
                    Month12 = table.Column<DateTime>(nullable: true),
                    Month12Purchases = table.Column<string>(nullable: true),
                    PerMonthAvgPurchase = table.Column<string>(nullable: true),
                    TotalMonthlyPurchase = table.Column<string>(nullable: true),
                    DailyPurchasesAmount = table.Column<string>(nullable: true),
                    DailyPurchaseFrequency = table.Column<string>(nullable: true),
                    DailyTotal = table.Column<string>(nullable: true),
                    WeeklyPurchasesAmount = table.Column<string>(nullable: true),
                    WeeklyPurchaseFrequency = table.Column<string>(nullable: true),
                    WeeklyTotal = table.Column<string>(nullable: true),
                    FortnightlyPurchasesAmount = table.Column<string>(nullable: true),
                    FortnightlyPurchaseFrequency = table.Column<string>(nullable: true),
                    FortnightlyTotal = table.Column<string>(nullable: true),
                    MonthlyPurchasesAmount = table.Column<string>(nullable: true),
                    MonthlyPurchaseFrequency = table.Column<string>(nullable: true),
                    MonthlyTotal = table.Column<string>(nullable: true),
                    QuaterlyPurchasesAmount = table.Column<string>(nullable: true),
                    QuaterlyPurchaseFrequency = table.Column<string>(nullable: true),
                    QuaterlyTotal = table.Column<string>(nullable: true),
                    SemiAnnuallyPurchasesAmount = table.Column<string>(nullable: true),
                    SemiAnnuallyPurchaseFrequency = table.Column<string>(nullable: true),
                    SemiAnnuallyTotal = table.Column<string>(nullable: true),
                    AnnuallyPurchasesAmount = table.Column<string>(nullable: true),
                    AnnuallyPurchaseFrequency = table.Column<string>(nullable: true),
                    AnnuallyTotal = table.Column<string>(nullable: true),
                    TotalMonthlyPurchaseTranche = table.Column<string>(nullable: true),
                    PurchaseToBeConsidered = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailChild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailGrandChild",
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
                    Fk_PurchaseDetailChildId = table.Column<int>(nullable: false),
                    SrNo = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    PerUnitPurchasePrice = table.Column<string>(nullable: true),
                    MonthlyPurchaseUnit = table.Column<string>(nullable: true),
                    TotalPurchase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailGrandChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "PurchaseDetailChild");

            migrationBuilder.DropTable(
                name: "PurchaseDetailGrandChild");
        }
    }
}
