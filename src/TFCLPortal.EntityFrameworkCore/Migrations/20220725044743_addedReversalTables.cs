using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedReversalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reversal",
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
                    InitiatedBy = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    AuthorizedBy = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reversal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLog",
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
                    DepositDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    Fk_AccountId = table.Column<int>(nullable: false),
                    AmountWords = table.Column<string>(nullable: true),
                    ModeOfPaymentOther = table.Column<string>(nullable: true),
                    CompanyBankId = table.Column<int>(nullable: false),
                    ModeOfPayment = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<bool>(nullable: true),
                    BalBefore = table.Column<decimal>(nullable: false),
                    BalAfter = table.Column<decimal>(nullable: false),
                    TransactionTableId = table.Column<int>(nullable: false),
                    isReversalEntry = table.Column<bool>(nullable: false),
                    fk_reversalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reversal");

            migrationBuilder.DropTable(
                name: "TransactionLog");
        }
    }
}
