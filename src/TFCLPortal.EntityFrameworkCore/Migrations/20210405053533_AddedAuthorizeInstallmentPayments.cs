using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AddedAuthorizeInstallmentPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizeInstallmentPayment",
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
                    NatureOfPaymentOthers = table.Column<string>(nullable: true),
                    InstallmentDueDate = table.Column<DateTime>(nullable: false),
                    InstallmentAmount = table.Column<decimal>(nullable: false),
                    NoOfInstallment = table.Column<int>(nullable: false),
                    PreviousBalance = table.Column<decimal>(nullable: false),
                    DueAmount = table.Column<decimal>(nullable: false),
                    ExcessShortPayment = table.Column<decimal>(nullable: false),
                    ModeOfPayment = table.Column<string>(nullable: true),
                    ModeOfPaymentOthers = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    AmountWords = table.Column<string>(nullable: true),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    FK_CompanyBankId = table.Column<int>(nullable: false),
                    isLateDaysApplied = table.Column<bool>(nullable: false),
                    LateDays = table.Column<int>(nullable: false),
                    LateDaysPenalty = table.Column<decimal>(nullable: false),
                    RejectionReason = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeInstallmentPayment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizeInstallmentPayment");
        }
    }
}
