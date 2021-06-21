using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInApplicationWiseDeviationModelupdationReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "updationReason",
                table: "ApplicationWiseDeviationVariable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updationReason",
                table: "ApplicationWiseDeviationVariable");
        }
    }
}
