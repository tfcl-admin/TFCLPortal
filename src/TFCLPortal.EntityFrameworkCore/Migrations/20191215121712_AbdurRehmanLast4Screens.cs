using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AbdurRehmanLast4Screens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoApplicantDetails",
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
                    FullName = table.Column<string>(nullable: true),
                    SDW = table.Column<string>(nullable: true),
                    CNICNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Tehsil = table.Column<string>(nullable: true),
                    UCNumber = table.Column<string>(nullable: true),
                    MouzaOrTown = table.Column<string>(nullable: true),
                    RealtionshipWithApplicant = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    BusinessAddress = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    EmployerName = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoApplicantDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForSDE",
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
                    ApplicantReputationId = table.Column<int>(nullable: false),
                    DoubtfulComment = table.Column<string>(nullable: true),
                    UtilityBillPaymentId = table.Column<int>(nullable: false),
                    Delayed = table.Column<int>(nullable: false),
                    referenceCheckId = table.Column<int>(nullable: false),
                    KnowApplicantSince = table.Column<string>(nullable: true),
                    RecommendedLoanAmount = table.Column<decimal>(nullable: false),
                    RecommendedTenure = table.Column<string>(nullable: true),
                    RecommendedGracePeriod = table.Column<string>(nullable: true),
                    UtilizationOfLoan = table.Column<string>(nullable: true),
                    ObservationComment = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForSDE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuarantorDetails",
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
                    FullName = table.Column<string>(nullable: true),
                    SDW = table.Column<string>(nullable: true),
                    CNICNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Tehsil = table.Column<string>(nullable: true),
                    UCNumber = table.Column<string>(nullable: true),
                    MouzaOrTown = table.Column<string>(nullable: true),
                    RealtionshipWithApplicant = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    BusinessAddress = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    EmployerName = table.Column<string>(nullable: true),
                    IncomeAvailableForInstallment = table.Column<string>(nullable: true),
                    MonthlyIncome = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuarantorDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
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
                    FullName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    KnowApplicantSince = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoApplicantDetails");

            migrationBuilder.DropTable(
                name: "ForSDE");

            migrationBuilder.DropTable(
                name: "GuarantorDetails");

            migrationBuilder.DropTable(
                name: "Preferences");
        }
    }
}
