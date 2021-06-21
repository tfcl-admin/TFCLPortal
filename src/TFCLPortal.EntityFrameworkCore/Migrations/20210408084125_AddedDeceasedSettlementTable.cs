using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AddedDeceasedSettlementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeceasedSettlement",
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
                    OsPrincipalAmount = table.Column<decimal>(nullable: false),
                    OsMarkupAmount = table.Column<decimal>(nullable: false),
                    TotalAmountPayable = table.Column<decimal>(nullable: false),
                    AmountDeposited = table.Column<decimal>(nullable: false),
                    isAuthorized = table.Column<bool>(nullable: true),
                    RejectionReason = table.Column<string>(nullable: true),
                    isManagerAuthorized = table.Column<bool>(nullable: true),
                    ManagerRejectionReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeceasedSettlement", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeceasedSettlement");
        }
    }
}
