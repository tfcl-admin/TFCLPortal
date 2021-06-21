using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedEarlySettlementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarlySettlement",
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
                    LoanAmount = table.Column<decimal>(nullable: false),
                    Markup = table.Column<decimal>(nullable: false),
                    OsPrincipalAmount = table.Column<decimal>(nullable: false),
                    OsMarkupAmount = table.Column<decimal>(nullable: false),
                    LastPaidInstallmentDate = table.Column<DateTime>(nullable: false),
                    TentativeSettlementDate = table.Column<DateTime>(nullable: false),
                    OneDayMarkup = table.Column<decimal>(nullable: false),
                    DaysConsumed = table.Column<decimal>(nullable: false),
                    isEarlySettlementCharges = table.Column<bool>(nullable: false),
                    EarlySettlmentCharges = table.Column<decimal>(nullable: false),
                    FEDonESC = table.Column<decimal>(nullable: false),
                    PrincipalPayable = table.Column<decimal>(nullable: false),
                    previousBalance = table.Column<decimal>(nullable: false),
                    totalAmountPayable = table.Column<decimal>(nullable: false),
                    amountDeposited = table.Column<decimal>(nullable: false),
                    isLateDays = table.Column<bool>(nullable: false),
                    LatePaymentCharges = table.Column<decimal>(nullable: false),
                    FEDonLPC = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarlySettlement", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarlySettlement");
        }
    }
}
