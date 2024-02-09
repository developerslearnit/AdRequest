using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnusedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupResource");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StaffRecord",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "StaffRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "StaffRecord");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "StaffRecord");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GroupName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    GrandParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResourceType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffRecordStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserGroupId);
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_StaffRecord_StaffRecordStaffId",
                        column: x => x.StaffRecordStaffId,
                        principalTable: "StaffRecord",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupResource",
                columns: table => new
                {
                    GroupResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupResource", x => x.GroupResourceId);
                    table.ForeignKey(
                        name: "FK_GroupResource_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_SNo",
                table: "Group",
                column: "SNo");

            migrationBuilder.CreateIndex(
                name: "IX_GroupResource_GroupId",
                table: "GroupResource",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupResource_ResourceId",
                table: "GroupResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_StaffRecordStaffId",
                table: "UserGroup",
                column: "StaffRecordStaffId");
        }
    }
}
