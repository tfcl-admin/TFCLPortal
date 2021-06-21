using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class BusinessDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessDetail",
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
                    SchoolName = table.Column<string>(nullable: true),
                    SchoolType = table.Column<int>(nullable: false),
                    IsAnyFracnchiseOfSchoolNetwork = table.Column<string>(nullable: true),
                    NameOfFracnchiseSchoolNetwork = table.Column<string>(nullable: true),
                    LegalStatus = table.Column<int>(nullable: false),
                    EstablishedSince = table.Column<DateTime>(nullable: false),
                    IsSchoolRegistered = table.Column<string>(nullable: true),
                    SchoolRegisterSince = table.Column<DateTime>(nullable: false),
                    RegisterAuthority = table.Column<string>(nullable: true),
                    IfNoRegisteredWhy = table.Column<string>(nullable: true),
                    SchoolAddress = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Tehsil = table.Column<string>(nullable: true),
                    UC_NO = table.Column<string>(nullable: true),
                    Moza_Town = table.Column<string>(nullable: true),
                    NearestLandmark = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    SchoolPlaceOwnership = table.Column<int>(nullable: false),
                    NumberOfSchoolBranches = table.Column<int>(nullable: false),
                    GenderOfTheStudent = table.Column<string>(nullable: true),
                    TotalExperienceInEducationIndustry = table.Column<DateTime>(nullable: false),
                    PreviousExperience = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    SchoolLandLine = table.Column<string>(nullable: true),
                    CurrentAddressSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetail", x => x.Id);
                });

            

            migrationBuilder.CreateTable(
                name: "School_Branch",
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
                    SchoolAddress = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Tehsil = table.Column<string>(nullable: true),
                    UC_NO = table.Column<string>(nullable: true),
                    Moza_Town = table.Column<string>(nullable: true),
                    NearestLandmark = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    SchoolPlaceOwnership = table.Column<int>(nullable: false),
                    Fk_BusinessDetailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Branch", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessDetail");

           

            migrationBuilder.DropTable(
                name: "School_Branch");
        }
    }
}
