using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class ContactDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactDetail",
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
                    PresentAddress = table.Column<string>(nullable: true),
                    PresentProvince = table.Column<string>(nullable: true),
                    PresentDistrict = table.Column<string>(nullable: true),
                    PresentTehsil = table.Column<string>(nullable: true),
                    PresentUCNo = table.Column<string>(nullable: true),
                    PresentMouzaTown = table.Column<string>(nullable: true),
                    PresentNearestLandMark = table.Column<string>(nullable: true),
                    OwnershipStatus = table.Column<int>(nullable: false),
                    CurrentAddressSince = table.Column<DateTime>(nullable: false),
                    permanentAddress = table.Column<string>(nullable: true),
                    permanentProvince = table.Column<string>(nullable: true),
                    permanentDistrict = table.Column<string>(nullable: true),
                    permanentTehsil = table.Column<string>(nullable: true),
                    permanentUCNo = table.Column<string>(nullable: true),
                    permanentMouzaTown = table.Column<string>(nullable: true),
                    permanentNearestLandMark = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    LandlineNo = table.Column<string>(nullable: true),
                    AlternateMobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetail");
        }
    }
}
