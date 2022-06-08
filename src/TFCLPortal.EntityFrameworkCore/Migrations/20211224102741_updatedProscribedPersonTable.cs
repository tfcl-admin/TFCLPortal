using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updatedProscribedPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province",
                table: "ProscribedPersons",
                newName: "province");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProscribedPersons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "FatherName",
                table: "ProscribedPersons",
                newName: "fatherName");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "ProscribedPersons",
                newName: "district");

            migrationBuilder.RenameColumn(
                name: "CNIC",
                table: "ProscribedPersons",
                newName: "cnic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "province",
                table: "ProscribedPersons",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProscribedPersons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "fatherName",
                table: "ProscribedPersons",
                newName: "FatherName");

            migrationBuilder.RenameColumn(
                name: "district",
                table: "ProscribedPersons",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "cnic",
                table: "ProscribedPersons",
                newName: "CNIC");
        }
    }
}
