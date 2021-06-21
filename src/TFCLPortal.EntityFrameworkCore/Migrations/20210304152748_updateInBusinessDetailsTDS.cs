using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInBusinessDetailsTDS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BusinessType",
                table: "BusinessDetailTDS",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BusinessType",
                table: "BusinessDetailTDS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
