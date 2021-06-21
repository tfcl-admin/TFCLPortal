using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedExtraFieldsInMobilization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CnicIssueDate",
                table: "MobilizationTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "MobilizationTable",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CnicIssueDate",
                table: "MobilizationTable");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MobilizationTable");
        }
    }
}
