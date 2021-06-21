using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedMcrcDecisionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "McrcDecision",
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
                    McrcId = table.Column<string>(nullable: true),
                    McrcMember1UserId = table.Column<int>(nullable: false),
                    McrcMember1Recommendation = table.Column<string>(nullable: true),
                    McrcMember1Reason = table.Column<string>(nullable: true),
                    McrcMember2UserId = table.Column<int>(nullable: false),
                    McrcMember2Recommendation = table.Column<string>(nullable: true),
                    McrcMember2Reason = table.Column<string>(nullable: true),
                    McrcMember3UserId = table.Column<int>(nullable: false),
                    McrcMember3Recommendation = table.Column<string>(nullable: true),
                    McrcMember3Reason = table.Column<string>(nullable: true),
                    McrcMember4UserId = table.Column<int>(nullable: false),
                    McrcMember4Recommendation = table.Column<string>(nullable: true),
                    McrcMember4Reason = table.Column<string>(nullable: true),
                    McrcMember5UserId = table.Column<int>(nullable: false),
                    McrcMember5Recommendation = table.Column<string>(nullable: true),
                    McrcMember5Reason = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_McrcDecision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "McrcDecision");
        }
    }
}
