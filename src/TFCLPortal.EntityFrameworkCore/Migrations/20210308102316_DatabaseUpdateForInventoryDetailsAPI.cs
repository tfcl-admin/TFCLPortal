using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class DatabaseUpdateForInventoryDetailsAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryEntrySource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryEntrySource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryRecordMaintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryRecordMaintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TdsInventoryDetail",
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
                    GrandTotalSalePrice = table.Column<string>(nullable: true),
                    GrandTotalPurchasePrice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TdsInventoryDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TdsInventoryDetailChild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Fk_TdsInventoryDetail = table.Column<int>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    TotalInventoryQty = table.Column<string>(nullable: true),
                    TotalInventoryPurchasePrice = table.Column<string>(nullable: true),
                    TotalInventoryTotalPurchasePrice = table.Column<string>(nullable: true),
                    TotalInventorySalePrice = table.Column<string>(nullable: true),
                    TotalInventoryTotalSalePrice = table.Column<string>(nullable: true),
                    TotalVariancePercentage = table.Column<string>(nullable: true),
                    InventoryRecordMaintenance = table.Column<int>(nullable: false),
                    InventoryEntrySource = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TdsInventoryDetailChild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TdsInventoryDetailGrandChild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Fk_TdsInventoryDetailChild = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    qty = table.Column<string>(nullable: true),
                    PurchasedPrice = table.Column<string>(nullable: true),
                    TotalPurchasedPrice = table.Column<string>(nullable: true),
                    SalePrice = table.Column<string>(nullable: true),
                    TotalSalePrice = table.Column<string>(nullable: true),
                    GrossMargin = table.Column<string>(nullable: true),
                    PhysicallyVerified = table.Column<string>(nullable: true),
                    VariancePercentage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TdsInventoryDetailGrandChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryEntrySource");

            migrationBuilder.DropTable(
                name: "InventoryRecordMaintenance");

            migrationBuilder.DropTable(
                name: "TdsInventoryDetail");

            migrationBuilder.DropTable(
                name: "TdsInventoryDetailChild");

            migrationBuilder.DropTable(
                name: "TdsInventoryDetailGrandChild");
        }
    }
}
