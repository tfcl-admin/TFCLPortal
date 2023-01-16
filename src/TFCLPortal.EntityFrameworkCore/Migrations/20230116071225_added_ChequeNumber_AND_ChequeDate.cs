using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class added_ChequeNumber_AND_ChequeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChequeDate",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChequeNo",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChequeDate",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ChequeNo",
                table: "Schedule");
        }
    }
}
