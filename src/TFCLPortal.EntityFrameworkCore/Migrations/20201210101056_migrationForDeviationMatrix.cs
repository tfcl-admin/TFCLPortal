using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class migrationForDeviationMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationWiseDeviationVariable",
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
                    fk_ProductId = table.Column<int>(nullable: false),
                    MinLimitForUnsecuredLoan = table.Column<string>(nullable: true),
                    MaxLimitForUnsecuredLoan = table.Column<string>(nullable: true),
                    ApplicantMinAge = table.Column<string>(nullable: true),
                    ApplicantMaxAge = table.Column<string>(nullable: true),
                    BusinessAgeYears = table.Column<string>(nullable: true),
                    BusinessAgeAtCurrentPlaceYears = table.Column<string>(nullable: true),
                    MinPercentageOfSAexpAgainstSAincome = table.Column<string>(nullable: true),
                    MaxPercentageOfNAItotalSchoolRevenue = table.Column<string>(nullable: true),
                    MinPercentageOfHHEtotalSchoolRevenue = table.Column<string>(nullable: true),
                    MaxLimitForInstallmentRatio = table.Column<string>(nullable: true),
                    GuarantorMinAge = table.Column<string>(nullable: true),
                    GuarantorMaxAge = table.Column<string>(nullable: true),
                    Markup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationWiseDeviationVariable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviationApproval",
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
                    Reason = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    DocumentUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviationApproval", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviationMatrix",
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
                    fk_ProductId = table.Column<int>(nullable: false),
                    MinLimitForUnsecuredLoan = table.Column<string>(nullable: true),
                    MaxLimitForUnsecuredLoan = table.Column<string>(nullable: true),
                    ApplicantMinAge = table.Column<string>(nullable: true),
                    ApplicantMaxAge = table.Column<string>(nullable: true),
                    BusinessAgeYears = table.Column<string>(nullable: true),
                    BusinessAgeAtCurrentPlaceYears = table.Column<string>(nullable: true),
                    MinPercentageOfSAexpAgainstSAincome = table.Column<string>(nullable: true),
                    MaxPercentageOfNAItotalSchoolRevenue = table.Column<string>(nullable: true),
                    MinPercentageOfHHEtotalSchoolRevenue = table.Column<string>(nullable: true),
                    MaxLimitForInstallmentRatio = table.Column<string>(nullable: true),
                    GuarantorMinAge = table.Column<string>(nullable: true),
                    GuarantorMaxAge = table.Column<string>(nullable: true),
                    isActive = table.Column<string>(nullable: true),
                    updationReason = table.Column<string>(nullable: true),
                    approvalFileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviationMatrix", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationWiseDeviationVariable");

            migrationBuilder.DropTable(
                name: "DeviationApproval");

            migrationBuilder.DropTable(
                name: "DeviationMatrix");
        }
    }
}
