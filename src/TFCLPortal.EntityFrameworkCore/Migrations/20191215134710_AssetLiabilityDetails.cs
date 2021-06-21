using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AssetLiabilityDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetLiabilityDetail",
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
                    AssetLandBuliding = table.Column<decimal>(nullable: false),
                    AssetFurnitureFixture = table.Column<decimal>(nullable: false),
                    AssetAccountReceivable = table.Column<decimal>(nullable: false),
                    AssetCashInHandAtBank = table.Column<decimal>(nullable: false),
                    AssetVehicle = table.Column<decimal>(nullable: false),
                    AssetEquipment = table.Column<decimal>(nullable: false),
                    AssetCommittee = table.Column<decimal>(nullable: false),
                    OtherAssets = table.Column<decimal>(nullable: false),
                    TotalBusinessAsset = table.Column<decimal>(nullable: false),
                    AssetBusinessNetWorth = table.Column<decimal>(nullable: false),
                    TotalHouseholdAsset = table.Column<decimal>(nullable: false),
                    AssetHouseholdNetWorth = table.Column<decimal>(nullable: false),
                    LiablityLoanPayebleBank = table.Column<decimal>(nullable: false),
                    LiablityAdvanceReceived = table.Column<decimal>(nullable: false),
                    LiablityAccountPayable = table.Column<decimal>(nullable: false),
                    LiablityCommittee = table.Column<decimal>(nullable: false),
                    OtherLiablity = table.Column<decimal>(nullable: false),
                    TotalBusinessLiability = table.Column<decimal>(nullable: false),
                    TotalHouseholdLiability = table.Column<decimal>(nullable: false),
                    BorrowerNetWorthLiability = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLiabilityDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetLiabilityDetail");
        }
    }
}
