using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class Added_GLCode_inDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GLCode",
                table: "Applicationz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GLCode",
                table: "Applicationz");
        }
    }
}
