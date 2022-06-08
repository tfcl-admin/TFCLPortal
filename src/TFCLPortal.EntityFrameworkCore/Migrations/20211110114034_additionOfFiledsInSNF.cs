using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class additionOfFiledsInSNF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DropoutStudents",
                table: "SchoolNonFinancial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtherPaymentBehaviour",
                table: "SchoolNonFinancial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OtherPaymentBehaviour",
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
                    table.PrimaryKey("PK_OtherPaymentBehaviour", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherPaymentBehaviour");

            migrationBuilder.DropColumn(
                name: "DropoutStudents",
                table: "SchoolNonFinancial");

            migrationBuilder.DropColumn(
                name: "OtherPaymentBehaviour",
                table: "SchoolNonFinancial");
        }
    }
}
