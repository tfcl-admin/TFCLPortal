using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateForNonAssociatedIncomeApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NonAssociatedIncome",
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
                    isNonAssociatedIncome = table.Column<string>(nullable: true),
                    TotalNonAssociatedIncome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonAssociatedIncome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonAssociatedIncomeChild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Fk_NonAssociatedIncome = table.Column<int>(nullable: false),
                    OtherOccupation = table.Column<int>(nullable: true),
                    OtherOccupationOthers = table.Column<string>(nullable: true),
                    SourceOfIncome = table.Column<int>(nullable: true),
                    SourceOfIncomeOthers = table.Column<string>(nullable: true),
                    DocumentProof = table.Column<bool>(nullable: true),
                    ActualRevenue = table.Column<string>(nullable: true),
                    ConsideredPercentage = table.Column<string>(nullable: true),
                    ConsideredAmount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonAssociatedIncomeChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonAssociatedIncome");

            migrationBuilder.DropTable(
                name: "NonAssociatedIncomeChild");
        }
    }
}
