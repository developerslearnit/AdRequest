using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PayRequesUpdate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequest_StaffRecord_StaffRecordStaffId",
                table: "PaymentRequest");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRequest_StaffRecordStaffId",
                table: "PaymentRequest");

            migrationBuilder.DropColumn(
                name: "StaffRecordStaffId",
                table: "PaymentRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StaffRecordStaffId",
                table: "PaymentRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_StaffRecordStaffId",
                table: "PaymentRequest",
                column: "StaffRecordStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequest_StaffRecord_StaffRecordStaffId",
                table: "PaymentRequest",
                column: "StaffRecordStaffId",
                principalTable: "StaffRecord",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
