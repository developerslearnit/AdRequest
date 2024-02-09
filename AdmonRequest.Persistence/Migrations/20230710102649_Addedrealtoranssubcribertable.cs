using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addedrealtoranssubcribertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonRegistration",
                columns: table => new
                {
                    PersonRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PersonRegistrationNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pictures = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    PreferCommunication = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRegistration", x => x.PersonRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "PersonAdditionalInfo",
                columns: table => new
                {
                    PersonAdditionalInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PersonRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonAdditionalInfoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAdditionalInfo", x => x.PersonAdditionalInfoId);
                    table.ForeignKey(
                        name: "FK_PersonAdditionalInfo_PersonRegistration_PersonRegistrationId",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistration",
                        principalColumn: "PersonRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAdditionalInfo_PersonRegistrationId",
                table: "PersonAdditionalInfo",
                column: "PersonRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistration_SNo",
                table: "PersonRegistration",
                column: "SNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAdditionalInfo");

            migrationBuilder.DropTable(
                name: "PersonRegistration");
        }
    }
}
