using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class added2tablesForAPIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PsychometricIndicator",
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
                    ApplicationId = table.Column<int>(nullable: false),
                    PercentageToSteal = table.Column<int>(nullable: false),
                    AvoidConflict = table.Column<int>(nullable: false),
                    MotivationToRunSchool = table.Column<int>(nullable: false),
                    BusinessLuck = table.Column<int>(nullable: false),
                    HopefulForFuture = table.Column<int>(nullable: false),
                    DigitalInitiatives = table.Column<int>(nullable: false),
                    TeacherTrainings = table.Column<int>(nullable: false),
                    ParentEngagement = table.Column<int>(nullable: false),
                    MixExpenses = table.Column<string>(nullable: true),
                    ComparedFee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychometricIndicator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolNonFinancial",
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
                    ApplicationId = table.Column<int>(nullable: false),
                    BuildingCondition = table.Column<int>(nullable: false),
                    PowerBackup = table.Column<string>(nullable: true),
                    FirstAid = table.Column<string>(nullable: true),
                    AyasPresent = table.Column<string>(nullable: true),
                    SeperateWashrooms = table.Column<string>(nullable: true),
                    ProperLighting = table.Column<string>(nullable: true),
                    CleanWater = table.Column<string>(nullable: true),
                    FunctionalComputerLab = table.Column<string>(nullable: true),
                    SchoolManagementSystem = table.Column<string>(nullable: true),
                    SchoolDecor = table.Column<string>(nullable: true),
                    LearningAid = table.Column<string>(nullable: true),
                    TeacherTrainings = table.Column<string>(nullable: true),
                    ChildProtection = table.Column<string>(nullable: true),
                    EmergencyExits = table.Column<string>(nullable: true),
                    SecurityGuards = table.Column<string>(nullable: true),
                    HealthEnvironment = table.Column<string>(nullable: true),
                    FinancialRecords = table.Column<int>(nullable: false),
                    BusinessSuccession = table.Column<string>(nullable: true),
                    BusinessRadius = table.Column<int>(nullable: false),
                    TransactionHistory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolNonFinancial", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychometricIndicator");

            migrationBuilder.DropTable(
                name: "SchoolNonFinancial");
        }
    }
}
