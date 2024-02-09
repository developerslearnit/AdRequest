﻿// <auto-generated />
using System;
using AdmonRequest.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdmonRequest.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230702145658_PayRequestUpdate")]
    partial class PayRequestUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdmonRequest.Domain.Entities.ApprovalStage", b =>
                {
                    b.Property<Guid>("ApprovalStageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ApprovalStageId");

                    b.ToTable("ApprovalStage", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetCategory", b =>
                {
                    b.Property<Guid>("BudgetCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BudgetCategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BudgetCategoryId");

                    b.ToTable("BudgetCategory", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetDetail", b =>
                {
                    b.Property<Guid>("BudgetDetailPeriodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("AccountID")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("ApplicableToUnit")
                        .HasColumnType("bit");

                    b.Property<decimal>("BudgetAmount")
                        .HasColumnType("decimal(18,5)");

                    b.Property<Guid>("BudgetCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentSubUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BudgetDetailPeriodID");

                    b.HasIndex("BudgetCategoryId");

                    b.HasIndex("BudgetMethodId");

                    b.HasIndex("BudgetPeriodId");

                    b.HasIndex("BudgetYearId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DepartmentSubUnitId");

                    b.ToTable("BudgetDetail", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetMethod", b =>
                {
                    b.Property<Guid>("BudgetMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BudgetMethodName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("BudgetMethodId");

                    b.ToTable("BudgetMethod", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetPeriod", b =>
                {
                    b.Property<Guid>("BudgetPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BudgetPeriodName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<Guid>("BudgetYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.HasKey("BudgetPeriodId");

                    b.HasIndex("BudgetYearId");

                    b.ToTable("BudgetPeriod", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetTracking", b =>
                {
                    b.Property<Guid>("BudgetTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("BudgetDetailPeriodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,5)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,5)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("GJSource")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Syncronized")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BudgetTrackingId");

                    b.ToTable("BudgetTracking", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetYear", b =>
                {
                    b.Property<Guid>("BudgetYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BudgetYearName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BudgetYearId");

                    b.ToTable("BudgetYear", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.DepartmentSubUnit", b =>
                {
                    b.Property<Guid>("DepartmentSubUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubUnitName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DepartmentSubUnitId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentSubUnit", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("GroupId");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.GroupResource", b =>
                {
                    b.Property<Guid>("GroupResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupResourceId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ResourceId");

                    b.ToTable("GroupResource", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.PaymentRequest", b =>
                {
                    b.Property<Guid>("PaymentRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,5)");

                    b.Property<Guid?>("ApprovalStatus")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeneficiaryName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<Guid?>("BudgetCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BudgetPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DeductionAmount")
                        .HasColumnType("decimal(18,5)");

                    b.Property<Guid>("DepartmentSubUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsSyncronized")
                        .HasColumnType("bit");

                    b.Property<string>("LPONo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RefNo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SNo")
                        .HasColumnType("int");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaffRecordStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VoteType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PaymentRequestId");

                    b.HasIndex("DepartmentSubUnitId");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("StaffRecordStaffId");

                    b.ToTable("PaymentRequest", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.RequestType", b =>
                {
                    b.Property<Guid>("RequestTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdvance")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDirectPayment")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProject")
                        .HasColumnType("bit");

                    b.Property<bool>("ReduceBuget")
                        .HasColumnType("bit");

                    b.Property<string>("RequestTypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RequestTypeId");

                    b.ToTable("RequestType", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.Resource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Area")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<Guid?>("GrandParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasChildren")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourceType")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("ResourceId");

                    b.ToTable("Resource", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.StaffRecord", b =>
                {
                    b.Property<Guid>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(355)
                        .HasColumnType("nvarchar(355)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("StaffId");

                    b.ToTable("StaffRecord", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaffRecordStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserGroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("StaffRecordStaffId");

                    b.ToTable("UserGroup", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.VoteType", b =>
                {
                    b.Property<Guid>("VoteTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("VoteTypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VoteTypeId");

                    b.ToTable("VoteType", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetDetail", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.BudgetCategory", "BudgetCategory")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.BudgetMethod", "BudgetMethod")
                        .WithMany()
                        .HasForeignKey("BudgetMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.BudgetPeriod", "BudgetPeriod")
                        .WithMany()
                        .HasForeignKey("BudgetPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.BudgetYear", "BudgetYear")
                        .WithMany()
                        .HasForeignKey("BudgetYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.DepartmentSubUnit", "DepartmentSubUnit")
                        .WithMany()
                        .HasForeignKey("DepartmentSubUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetCategory");

                    b.Navigation("BudgetMethod");

                    b.Navigation("BudgetPeriod");

                    b.Navigation("BudgetYear");

                    b.Navigation("Department");

                    b.Navigation("DepartmentSubUnit");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.BudgetPeriod", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.BudgetYear", "BudgetYear")
                        .WithMany()
                        .HasForeignKey("BudgetYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetYear");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.DepartmentSubUnit", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.GroupResource", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.PaymentRequest", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.DepartmentSubUnit", "DepartmentSubUnit")
                        .WithMany()
                        .HasForeignKey("DepartmentSubUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.StaffRecord", "StaffRecord")
                        .WithMany()
                        .HasForeignKey("StaffRecordStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentSubUnit");

                    b.Navigation("RequestType");

                    b.Navigation("StaffRecord");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.UserGroup", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdmonRequest.Domain.Entities.StaffRecord", "StaffRecord")
                        .WithMany()
                        .HasForeignKey("StaffRecordStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("StaffRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
