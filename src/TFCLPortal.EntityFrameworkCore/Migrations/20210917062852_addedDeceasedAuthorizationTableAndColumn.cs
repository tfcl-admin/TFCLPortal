using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedDeceasedAuthorizationTableAndColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeceased",
                table: "Applicationz",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DeceasedAuthorization",
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
                    ClientName = table.Column<string>(nullable: true),
                    CNIC = table.Column<string>(nullable: true),
                    DateOfDeath = table.Column<string>(nullable: true),
                    ReasonOfDeath = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<bool>(nullable: true),
                    RejectionReason = table.Column<string>(nullable: true),
                    ProofUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeceasedAuthorization", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeceasedAuthorization");

            migrationBuilder.DropColumn(
                name: "isDeceased",
                table: "Applicationz");
        }
    }
}
