using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalStage",
                columns: table => new
                {
                    ApprovalStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    StageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStage", x => x.ApprovalStageId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCategory",
                columns: table => new
                {
                    BudgetCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetCategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategory", x => x.BudgetCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetMethod",
                columns: table => new
                {
                    BudgetMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetMethodName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetMethod", x => x.BudgetMethodId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTracking",
                columns: table => new
                {
                    BudgetTrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetDetailPeriodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GJSource = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Syncronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTracking", x => x.BudgetTrackingId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetYear",
                columns: table => new
                {
                    BudgetYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetYearName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetYear", x => x.BudgetYearId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GroupName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    RequestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    RequestTypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReduceBuget = table.Column<bool>(type: "bit", nullable: false),
                    IsAdvance = table.Column<bool>(type: "bit", nullable: false),
                    IsProject = table.Column<bool>(type: "bit", nullable: false),
                    IsDirectPayment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.RequestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Controller = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrandParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResourceType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "StaffRecord",
                columns: table => new
                {
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    StaffName = table.Column<string>(type: "nvarchar(355)", maxLength: 355, nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRecord", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "VoteType",
                columns: table => new
                {
                    VoteTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    VoteTypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteType", x => x.VoteTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetPeriod",
                columns: table => new
                {
                    BudgetPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetPeriodName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BudgetYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    Open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPeriod", x => x.BudgetPeriodId);
                    table.ForeignKey(
                        name: "FK_BudgetPeriod_BudgetYear_BudgetYearId",
                        column: x => x.BudgetYearId,
                        principalTable: "BudgetYear",
                        principalColumn: "BudgetYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSubUnit",
                columns: table => new
                {
                    DepartmentSubUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SubUnitName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubUnit", x => x.DepartmentSubUnitId);
                    table.ForeignKey(
                        name: "FK_DepartmentSubUnit_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
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

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffRecordStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "BudgetDetail",
                columns: table => new
                {
                    BudgetDetailPeriodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    BudgetDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    BudgetMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetYearId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentSubUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicableToUnit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDetail", x => x.BudgetDetailPeriodID);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_BudgetCategory_BudgetCategoryId",
                        column: x => x.BudgetCategoryId,
                        principalTable: "BudgetCategory",
                        principalColumn: "BudgetCategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_BudgetMethod_BudgetMethodId",
                        column: x => x.BudgetMethodId,
                        principalTable: "BudgetMethod",
                        principalColumn: "BudgetMethodId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_BudgetPeriod_BudgetPeriodId",
                        column: x => x.BudgetPeriodId,
                        principalTable: "BudgetPeriod",
                        principalColumn: "BudgetPeriodId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_BudgetYear_BudgetYearId",
                        column: x => x.BudgetYearId,
                        principalTable: "BudgetYear",
                        principalColumn: "BudgetYearId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_DepartmentSubUnit_DepartmentSubUnitId",
                        column: x => x.DepartmentSubUnitId,
                        principalTable: "DepartmentSubUnit",
                        principalColumn: "DepartmentSubUnitId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequest",
                columns: table => new
                {
                    PaymentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    RequestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentSubUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BudgetCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BudgetPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoteType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    LPONo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ApprovalStatus = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSyncronized = table.Column<bool>(type: "bit", nullable: false),
                    StaffRecordStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SNo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequest", x => x.PaymentRequestId);
                    table.ForeignKey(
                        name: "FK_PaymentRequest_DepartmentSubUnit_DepartmentSubUnitId",
                        column: x => x.DepartmentSubUnitId,
                        principalTable: "DepartmentSubUnit",
                        principalColumn: "DepartmentSubUnitId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaymentRequest_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaymentRequest_StaffRecord_StaffRecordStaffId",
                        column: x => x.StaffRecordStaffId,
                        principalTable: "StaffRecord",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetCategoryId",
                table: "BudgetDetail",
                column: "BudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetMethodId",
                table: "BudgetDetail",
                column: "BudgetMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetPeriodId",
                table: "BudgetDetail",
                column: "BudgetPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetYearId",
                table: "BudgetDetail",
                column: "BudgetYearId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_DepartmentId",
                table: "BudgetDetail",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_DepartmentSubUnitId",
                table: "BudgetDetail",
                column: "DepartmentSubUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPeriod_BudgetYearId",
                table: "BudgetPeriod",
                column: "BudgetYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubUnit_DepartmentId",
                table: "DepartmentSubUnit",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupResource_GroupId",
                table: "GroupResource",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupResource_ResourceId",
                table: "GroupResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_DepartmentSubUnitId",
                table: "PaymentRequest",
                column: "DepartmentSubUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_RequestTypeId",
                table: "PaymentRequest",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequest_StaffRecordStaffId",
                table: "PaymentRequest",
                column: "StaffRecordStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_StaffRecordStaffId",
                table: "UserGroup",
                column: "StaffRecordStaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalStage");

            migrationBuilder.DropTable(
                name: "BudgetDetail");

            migrationBuilder.DropTable(
                name: "BudgetTracking");

            migrationBuilder.DropTable(
                name: "GroupResource");

            migrationBuilder.DropTable(
                name: "PaymentRequest");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "VoteType");

            migrationBuilder.DropTable(
                name: "BudgetCategory");

            migrationBuilder.DropTable(
                name: "BudgetMethod");

            migrationBuilder.DropTable(
                name: "BudgetPeriod");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "DepartmentSubUnit");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "StaffRecord");

            migrationBuilder.DropTable(
                name: "BudgetYear");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
