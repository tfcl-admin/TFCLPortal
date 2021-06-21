using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class CollateralDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollateralDetail",
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
                    CollateralType = table.Column<int>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false),
                    CollateralOwnership = table.Column<int>(nullable: false),
                    BuildSince = table.Column<DateTime>(nullable: false),
                    PropertyAddress = table.Column<string>(nullable: true),
                    TotalArea = table.Column<string>(nullable: true),
                    CoveredArea = table.Column<string>(nullable: true),
                    PurchasePrice = table.Column<string>(nullable: true),
                    LandBuildingMarketPrice = table.Column<string>(nullable: true),
                    GovtEstimatedValue = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    MAKE = table.Column<string>(nullable: true),
                    ModelNo = table.Column<string>(nullable: true),
                    EngineNo = table.Column<string>(nullable: true),
                    ChasisNo = table.Column<string>(nullable: true),
                    HorsePowerCC = table.Column<string>(nullable: true),
                    MarketValue = table.Column<string>(nullable: true),
                    TDRNo = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    BranchAddress = table.Column<string>(nullable: true),
                    AmountTDR = table.Column<string>(nullable: true),
                    NoOFItemGold = table.Column<string>(nullable: true),
                    ItemDescriptionGold = table.Column<string>(nullable: true),
                    TotalGrossWeightGold = table.Column<string>(nullable: true),
                    TotalNetWeightGold = table.Column<string>(nullable: true),
                    MarketValueInGram = table.Column<string>(nullable: true),
                    MarketValueTotalGold = table.Column<string>(nullable: true),
                    GoldEvaluatorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollateralDetail");
        }
    }
}
