using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addpaymenttrackingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTracking",
                columns: table => new
                {
                    TrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SourceTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtherRefno = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTracking", x => x.TrackingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTracking_SNo",
                table: "PaymentTracking",
                column: "SNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTracking");
        }
    }
}
