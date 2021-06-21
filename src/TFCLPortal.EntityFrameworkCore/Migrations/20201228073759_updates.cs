using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "percentageOfProfitShare",
                table: "School_Branch",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "BranchManagerAction",
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
                    ActionType = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true),
                    ScreenName = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    ActionBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchManagerAction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchManagerAction");

            migrationBuilder.AlterColumn<int>(
                name: "percentageOfProfitShare",
                table: "School_Branch",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
