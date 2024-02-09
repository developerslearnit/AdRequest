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
    [Migration("20230706183143_StaffTableUpdate")]
    partial class StaffTableUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdmonRequest.Domain.Entitie.PaymentTracking", b =>
                {
                    b.Property<Guid>("TrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherRefno")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SNo"));

                    b.Property<Guid>("SourceTableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TrackingId");

                    b.HasIndex("SNo");

                    b.ToTable("PaymentTracking", (string)null);
                });

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

            modelBuilder.Entity("AdmonRequest.Domain.Entities.EmailWorker", b =>
                {
                    b.Property<Guid>("EmailWorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SentStatus")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ToAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("EmailWorkerId");

                    b.ToTable("EmailWorker", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.GeneralLedger", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("AccountPointSetupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AccountPointSetupID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AccountYearID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Accountclass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Accountid")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Beneficiary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Gjsource")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("InstrumentNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gjSourceParent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("particulars")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("trnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.ToTable("GeneralLedger", (string)null);
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SNo"));

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VoteType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PaymentRequestId");

                    b.HasIndex("DepartmentSubUnitId");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("SNo");

                    b.ToTable("PaymentRequest", (string)null);
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.RequestAttachment", b =>
                {
                    b.Property<Guid>("RequestAttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<byte[]>("Attachment")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileExt")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<Guid>("PaymentRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RequestAttachmentId");

                    b.HasIndex("PaymentRequestId");

                    b.ToTable("RequestAttachment", (string)null);
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

            modelBuilder.Entity("AdmonRequest.Domain.Entities.StaffRecord", b =>
                {
                    b.Property<Guid>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ApprovalStage")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

            modelBuilder.Entity("AdmonRequest.Domain.Entities.StatementofAccount", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("AccountUniqueID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccounttypeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Gjsource")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectDetailTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("particulars")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("trnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.ToTable("StatementofAccount", (string)null);
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

                    b.Navigation("DepartmentSubUnit");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("AdmonRequest.Domain.Entities.RequestAttachment", b =>
                {
                    b.HasOne("AdmonRequest.Domain.Entities.PaymentRequest", "PaymentRequest")
                        .WithMany()
                        .HasForeignKey("PaymentRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
