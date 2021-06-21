using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class GuarantorDetailAppService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AmlCftCheck",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AmlCftClearance",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CnicExpiryDate",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CreditBureauCheck",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditBureauStatus",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guaranteedAmount",
                table: "GuarantorDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "guaranteedLoanFI",
                table: "GuarantorDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "AmlCftCheck",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "AmlCftClearance",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "CnicExpiryDate",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "CreditBureauCheck",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "CreditBureauStatus",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "guaranteedAmount",
                table: "GuarantorDetails");

            migrationBuilder.DropColumn(
                name: "guaranteedLoanFI",
                table: "GuarantorDetails");
        }
    }
}
