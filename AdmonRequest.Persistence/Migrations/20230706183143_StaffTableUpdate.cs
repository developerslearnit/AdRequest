using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StaffTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveStatus",
                table: "StaffRecord",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovalStage",
                table: "StaffRecord",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "StaffRecord");

            migrationBuilder.DropColumn(
                name: "ApprovalStage",
                table: "StaffRecord");
        }
    }
}
