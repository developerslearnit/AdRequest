using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PayRequesUpdate03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "SNo",
                table: "PaymentRequest");

            //migrationBuilder.AddColumn<int>(
            //    name: "SNo",
            //    table: "PaymentRequest",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaymentRequest_SNo",
            //    table: "PaymentRequest",
            //    column: "SNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentRequest_SNo",
                table: "PaymentRequest");

            migrationBuilder.AlterColumn<int>(
                name: "SNo",
                table: "PaymentRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
