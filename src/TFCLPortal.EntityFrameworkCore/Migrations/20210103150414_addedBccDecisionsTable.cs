using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedBccDecisionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BccDecision",
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
                    BccId = table.Column<int>(nullable: false),
                    BccMember1UserId = table.Column<int>(nullable: false),
                    BccMember1Recommendation = table.Column<string>(nullable: true),
                    BccMember1Reason = table.Column<string>(nullable: true),
                    BccMember2UserId = table.Column<int>(nullable: false),
                    BccMember2Recommendation = table.Column<string>(nullable: true),
                    BccMember2Reason = table.Column<string>(nullable: true),
                    BccMember3UserId = table.Column<int>(nullable: false),
                    BccMember3Recommendation = table.Column<string>(nullable: true),
                    BccMember3Reason = table.Column<string>(nullable: true),
                    Decision = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    LoanAmount = table.Column<string>(nullable: true),
                    LoanTenure = table.Column<string>(nullable: true),
                    GraceDays = table.Column<string>(nullable: true),
                    AppliedMarkup = table.Column<string>(nullable: true),
                    CollateralAmount = table.Column<string>(nullable: true),
                    LTV = table.Column<string>(nullable: true),
                    CollateralEvaluation = table.Column<string>(nullable: true),
                    isDeferment = table.Column<string>(nullable: true),
                    DefermentPeriod = table.Column<string>(nullable: true),
                    isTranches = table.Column<string>(nullable: true),
                    TranchesDates = table.Column<string>(nullable: true),
                    TranchesAmount = table.Column<string>(nullable: true),
                    CheckName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BccDecision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BccDecision");
        }
    }
}
