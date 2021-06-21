using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class updateInBusinessDetailsTdsApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentageOfShareHolding",
                table: "BusinessDetailTDS",
                newName: "rentAgreementSignatoryOthers");

            migrationBuilder.RenameColumn(
                name: "BusinessDetail",
                table: "BusinessDetailTDS",
                newName: "SalesTaxNo");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "BusinessDetailTDS",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "BusinessDetailTDS",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "BusinessAge",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessType",
                table: "BusinessDetailTDS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BusinessTypeOthers",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalStatusOthers",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyRentSharingPercentage",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyShare",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfPartnerInvestorDirector",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatureOfBusinessOthers",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfPartnersInvestorsDirectors",
                table: "BusinessDetailTDS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NtnNo",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberofBusiness",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageOfProfitConsidered",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageOfProfitSharedApplicant",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentAgreementExpiryDate",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentAgreementSignatory",
                table: "BusinessDetailTDS",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAnyOtherBusiness",
                table: "BusinessDetailTDS",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessAge",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "BusinessTypeOthers",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "LegalStatusOthers",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "MonthlyRentSharingPercentage",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "MonthlyShare",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "NameOfPartnerInvestorDirector",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "NatureOfBusinessOthers",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "NoOfPartnersInvestorsDirectors",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "NtnNo",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "NumberofBusiness",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "PercentageOfProfitConsidered",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "PercentageOfProfitSharedApplicant",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "RentAgreementExpiryDate",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "RentAgreementSignatory",
                table: "BusinessDetailTDS");

            migrationBuilder.DropColumn(
                name: "isAnyOtherBusiness",
                table: "BusinessDetailTDS");

            migrationBuilder.RenameColumn(
                name: "rentAgreementSignatoryOthers",
                table: "BusinessDetailTDS",
                newName: "PercentageOfShareHolding");

            migrationBuilder.RenameColumn(
                name: "SalesTaxNo",
                table: "BusinessDetailTDS",
                newName: "BusinessDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "BusinessDetailTDS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "BusinessDetailTDS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
