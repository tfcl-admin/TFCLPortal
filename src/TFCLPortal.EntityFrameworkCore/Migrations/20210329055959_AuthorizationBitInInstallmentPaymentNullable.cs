using Microsoft.EntityFrameworkCore.Migrations;

namespace TFCLPortal.Migrations
{
    public partial class AuthorizationBitInInstallmentPaymentNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isAuthorized",
                table: "InstallmentPayment",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isAuthorized",
                table: "InstallmentPayment",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
