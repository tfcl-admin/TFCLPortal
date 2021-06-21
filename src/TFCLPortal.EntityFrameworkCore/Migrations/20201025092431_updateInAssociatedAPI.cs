using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInAssociatedAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgCharges",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "ConsideredAmount",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "ConsideredPercentage",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "DocumentProof",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "MonthlyRevenue",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "OtherAssociatedIncome",
                table: "AssociatedIncomeChild");

            migrationBuilder.DropColumn(
                name: "OtherAssociatedIncomeAmount",
                table: "AssociatedIncomeChild");

            migrationBuilder.RenameColumn(
                name: "YearlyRevenue",
                table: "AssociatedIncomeChild",
                newName: "TotalAssociatedIncome");

            migrationBuilder.RenameColumn(
                name: "OtherAssociatedIncomeOthers",
                table: "AssociatedIncomeChild",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "TotalAssociatedIncome",
                table: "AssociatedIncome",
                newName: "GrandTotalAssociatedIncome");

            migrationBuilder.CreateTable(
                name: "AssociatedIncomeGrandChild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Fk_AssociatedIncomeChild = table.Column<int>(nullable: false),
                    OtherAssociatedIncome = table.Column<int>(nullable: true),
                    OtherAssociatedIncomeOthers = table.Column<string>(nullable: true),
                    DocumentProof = table.Column<bool>(nullable: true),
                    NumberOfStudents = table.Column<string>(nullable: true),
                    AvgCharges = table.Column<string>(nullable: true),
                    YearlyRevenue = table.Column<string>(nullable: true),
                    MonthlyRevenue = table.Column<string>(nullable: true),
                    OtherAssociatedIncomeAmount = table.Column<string>(nullable: true),
                    ConsideredPercentage = table.Column<string>(nullable: true),
                    ConsideredAmount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatedIncomeGrandChild", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociatedIncomeGrandChild");

            migrationBuilder.RenameColumn(
                name: "TotalAssociatedIncome",
                table: "AssociatedIncomeChild",
                newName: "YearlyRevenue");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "AssociatedIncomeChild",
                newName: "OtherAssociatedIncomeOthers");

            migrationBuilder.RenameColumn(
                name: "GrandTotalAssociatedIncome",
                table: "AssociatedIncome",
                newName: "TotalAssociatedIncome");

            migrationBuilder.AddColumn<string>(
                name: "AvgCharges",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsideredAmount",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsideredPercentage",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DocumentProof",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyRevenue",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfStudents",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherAssociatedIncome",
                table: "AssociatedIncomeChild",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAssociatedIncomeAmount",
                table: "AssociatedIncomeChild",
                nullable: true);
        }
    }
}
