using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class Added_StudentDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetail",
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
                    StudentName = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    CNIC = table.Column<string>(nullable: true),
                    CNICExpiry = table.Column<DateTime>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<string>(nullable: true),
                    RelationWithClient = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    NumberOfDependents = table.Column<int>(nullable: false),
                    EIName = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    EnrolledDegree = table.Column<string>(nullable: true),
                    Others = table.Column<string>(nullable: true),
                    FinalSemester = table.Column<string>(nullable: true),
                    LastSemester = table.Column<string>(nullable: true),
                    FeeRequiredForSemesterNo = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetail");
        }
    }
}
