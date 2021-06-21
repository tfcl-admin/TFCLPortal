using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class OtherDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "LoanPurpose",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LoanPurpose", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "OtherDetail",
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
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    OtherNationality = table.Column<string>(nullable: true),
                    NTNNumber = table.Column<string>(nullable: true),
                    MotherMaidenName = table.Column<string>(nullable: true),
                    OtherOccupation = table.Column<int>(nullable: false),
                    OtherSourceOfFund = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDetail", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "PaymentFrequency",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentFrequency", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PersonalDetail",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        DeleterUserId = table.Column<long>(nullable: true),
            //        DeletionTime = table.Column<DateTime>(nullable: true),
            //        ApplicationId = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        ApplicantName = table.Column<string>(nullable: true),
            //        ParentName = table.Column<string>(nullable: true),
            //        CNIC = table.Column<string>(nullable: true),
            //        CNICExpiry = table.Column<DateTime>(nullable: false),
            //        BirthDate = table.Column<DateTime>(nullable: false),
            //        Gender = table.Column<int>(nullable: false),
            //        MaritalStatus = table.Column<int>(nullable: false),
            //        NumberOfDependents = table.Column<int>(nullable: false),
            //        Qualification = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PersonalDetail", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "LoanPurpose");

            migrationBuilder.DropTable(
                name: "OtherDetail");

            //migrationBuilder.DropTable(
            //    name: "PaymentFrequency");

            //migrationBuilder.DropTable(
            //    name: "PersonalDetail");
        }
    }
}
