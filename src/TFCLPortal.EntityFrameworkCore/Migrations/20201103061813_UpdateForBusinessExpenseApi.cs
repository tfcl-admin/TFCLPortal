using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class UpdateForBusinessExpenseApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessExpenseSchool",
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
                    Fk_BusinessExpense = table.Column<int>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    TeacherSalary = table.Column<string>(nullable: true),
                    OtherSalary = table.Column<string>(nullable: true),
                    RentAmount = table.Column<string>(nullable: true),
                    Utilities = table.Column<string>(nullable: true),
                    Entertainment = table.Column<string>(nullable: true),
                    RepairAndMaintenance = table.Column<string>(nullable: true),
                    Transportation = table.Column<string>(nullable: true),
                    Stationary = table.Column<string>(nullable: true),
                    RoyaltyFee = table.Column<string>(nullable: true),
                    Committee = table.Column<string>(nullable: true),
                    InternetCharges = table.Column<string>(nullable: true),
                    OtherExpenses = table.Column<string>(nullable: true),
                    TotalMonthlyExpenses = table.Column<string>(nullable: true),
                    ProvisionOfExpenses = table.Column<string>(nullable: true),
                    MonthlyBusinessExpenses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpenseSchool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessExpenseSchoolAcademy",
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
                    Fk_BusinessExpenseSchool = table.Column<int>(nullable: false),
                    AcademyName = table.Column<string>(nullable: true),
                    TeacherSalary = table.Column<string>(nullable: true),
                    OtherSalary = table.Column<string>(nullable: true),
                    RentAmount = table.Column<string>(nullable: true),
                    Utilities = table.Column<string>(nullable: true),
                    Entertainment = table.Column<string>(nullable: true),
                    RepairAndMaintenance = table.Column<string>(nullable: true),
                    Transportation = table.Column<string>(nullable: true),
                    Stationary = table.Column<string>(nullable: true),
                    RoyaltyFee = table.Column<string>(nullable: true),
                    Committee = table.Column<string>(nullable: true),
                    InternetCharges = table.Column<string>(nullable: true),
                    OtherExpenses = table.Column<string>(nullable: true),
                    TotalMonthlyExpenses = table.Column<string>(nullable: true),
                    ProvisionOfExpenses = table.Column<string>(nullable: true),
                    MonthlyBusinessExpenses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpenseSchoolAcademy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessExpenseSchoolAcademyClass",
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
                    Fk_BusinessExpenseSchoolAcademy = table.Column<int>(nullable: false),
                    ClassNameOrSubject = table.Column<string>(nullable: true),
                    Designation = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Salary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpenseSchoolAcademyClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessExpenseSchoolClass",
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
                    Fk_BusinessExpenseSchool = table.Column<int>(nullable: false),
                    ClassNameOrSubject = table.Column<string>(nullable: true),
                    Designation = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Salary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpenseSchoolClass", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessExpenseSchool");

            migrationBuilder.DropTable(
                name: "BusinessExpenseSchoolAcademy");

            migrationBuilder.DropTable(
                name: "BusinessExpenseSchoolAcademyClass");

            migrationBuilder.DropTable(
                name: "BusinessExpenseSchoolClass");
        }
    }
}
