using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailWorker",
                columns: table => new
                {
                    EmailWorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ToAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FromAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    SentStatus = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailWorker", x => x.EmailWorkerId);
                });

            migrationBuilder.CreateTable(
                name: "RequestAttachment",
                columns: table => new
                {
                    RequestAttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PaymentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachment = table.Column<byte>(type: "tinyint", nullable: false),
                    FileExt = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAttachment", x => x.RequestAttachmentId);
                    table.ForeignKey(
                        name: "FK_RequestAttachment_PaymentRequest_PaymentRequestId",
                        column: x => x.PaymentRequestId,
                        principalTable: "PaymentRequest",
                        principalColumn: "PaymentRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttachment_PaymentRequestId",
                table: "RequestAttachment",
                column: "PaymentRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailWorker");

            migrationBuilder.DropTable(
                name: "RequestAttachment");
        }
    }
}
