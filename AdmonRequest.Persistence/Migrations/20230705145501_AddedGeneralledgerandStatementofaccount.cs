using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedGeneralledgerandStatementofaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralLedger",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AccountYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountPointSetupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accountid = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    trnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gjsource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    gjSourceParent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountPointSetupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accountclass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficiary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "StatementofAccount",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AccountUniqueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    trnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gjsource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDetailTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccounttypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementofAccount", x => x.TransactionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralLedger");

            migrationBuilder.DropTable(
                name: "StatementofAccount");
        }
    }
}
