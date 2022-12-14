using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedcolumnsinWriteOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "WriteOff",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WriteOffAmountMarkup",
                table: "WriteOff",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WriteOffAmountPrincipal",
                table: "WriteOff",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "WriteOff");

            migrationBuilder.DropColumn(
                name: "WriteOffAmountMarkup",
                table: "WriteOff");

            migrationBuilder.DropColumn(
                name: "WriteOffAmountPrincipal",
                table: "WriteOff");
        }
    }
}
