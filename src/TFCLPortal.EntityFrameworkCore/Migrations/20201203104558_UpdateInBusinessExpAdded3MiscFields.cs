using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateInBusinessExpAdded3MiscFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel1",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel2",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel3",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue1",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue2",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue3",
                table: "BusinessExpenseSchoolAcademy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel1",
                table: "BusinessExpenseSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel2",
                table: "BusinessExpenseSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldLabel3",
                table: "BusinessExpenseSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue1",
                table: "BusinessExpenseSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue2",
                table: "BusinessExpenseSchool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalFieldValue3",
                table: "BusinessExpenseSchool",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel1",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel2",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel3",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue1",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue2",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue3",
                table: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel1",
                table: "BusinessExpenseSchool");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel2",
                table: "BusinessExpenseSchool");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldLabel3",
                table: "BusinessExpenseSchool");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue1",
                table: "BusinessExpenseSchool");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue2",
                table: "BusinessExpenseSchool");

            migrationBuilder.DropColumn(
                name: "AdditionalFieldValue3",
                table: "BusinessExpenseSchool");
        }
    }
}
