using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class addedDropdownsAndApiTableInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
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
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyType = table.Column<int>(nullable: false),
                    CompanyTypeOthers = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    MouzaTown = table.Column<string>(nullable: true),
                    UnionCouncil = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Tehsil = table.Column<string>(nullable: true),
                    CompanySince = table.Column<DateTime>(nullable: false),
                    CompanyBusinessDetails = table.Column<string>(nullable: true),
                    ClientDesignation = table.Column<string>(nullable: true),
                    ConcernedDepartment = table.Column<string>(nullable: true),
                    NatureOfEmployment = table.Column<int>(nullable: false),
                    NatureOfEmploymentOthers = table.Column<string>(nullable: true),
                    TenureOfEmploymentDesignation = table.Column<string>(nullable: true),
                    TenureOfEmploymentCompany = table.Column<string>(nullable: true),
                    TenureOfEmploymentOverall = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    CompanyNTN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatureOfEmployment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureOfEmployment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "NatureOfEmployment");
        }
    }
}
