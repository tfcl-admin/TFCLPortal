using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInHouseHoldIE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "HouseholdIncomeExpense",
                newName: "fk_HouseHoldParentID");

            migrationBuilder.AddColumn<string>(
                name: "HouseholdOwnerName",
                table: "HouseholdIncomeExpense",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HouseholdIncomeExpenseParent",
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
                    totalHouseHoldIncomeExpense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdIncomeExpenseParent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseholdIncomeExpenseParent");

            migrationBuilder.DropColumn(
                name: "HouseholdOwnerName",
                table: "HouseholdIncomeExpense");

            migrationBuilder.RenameColumn(
                name: "fk_HouseHoldParentID",
                table: "HouseholdIncomeExpense",
                newName: "ApplicationId");
        }
    }
}
