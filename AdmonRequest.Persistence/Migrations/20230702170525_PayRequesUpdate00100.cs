using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PayRequesUpdate00100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SNo",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Group_SNo",
                table: "Group",
                column: "SNo");

            migrationBuilder.AddColumn<int>(
             name: "SNo",
             table: "PaymentRequest",
             type: "int",
             nullable: false,
             defaultValue: 0)
             .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_SNo",
                table: "PaymentRequest",
                column: "SNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Group_SNo",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "SNo",
                table: "Group");
        }
    }
}
