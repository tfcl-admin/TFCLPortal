using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInInventoryDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TotalGrossMargin",
                table: "TdsInventoryDetailChild",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalGrossMargin",
                table: "TdsInventoryDetailChild",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
