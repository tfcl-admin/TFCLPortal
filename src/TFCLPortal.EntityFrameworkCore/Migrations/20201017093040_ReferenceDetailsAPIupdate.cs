using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class ReferenceDetailsAPIupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Preferences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipWithApplicant",
                table: "Preferences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationshipWithApplicantOthers",
                table: "Preferences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "RelationshipWithApplicant",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "RelationshipWithApplicantOthers",
                table: "Preferences");
        }
    }
}
