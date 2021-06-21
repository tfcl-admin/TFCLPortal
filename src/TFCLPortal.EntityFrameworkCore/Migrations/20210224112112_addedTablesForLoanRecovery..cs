using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedTablesForLoanRecovery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBankAccount",
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
                    Name = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    AccountTitle = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    IBAN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentPayment",
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
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    NatureOfPayment = table.Column<int>(nullable: false),
                    InstallmentDueDate = table.Column<DateTime>(nullable: false),
                    InstallmentAmount = table.Column<decimal>(nullable: false),
                    NoOfInstallment = table.Column<int>(nullable: false),
                    PreviousBalance = table.Column<decimal>(nullable: false),
                    DueAmount = table.Column<decimal>(nullable: false),
                    ModeOfPayment = table.Column<string>(nullable: true),
                    ModeOfPaymentOthers = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    AmountWords = table.Column<string>(nullable: true),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    FK_CompanyBankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatureOfPayment",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureOfPayment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBankAccount");

            migrationBuilder.DropTable(
                name: "InstallmentPayment");

            migrationBuilder.DropTable(
                name: "NatureOfPayment");
        }
    }
}
