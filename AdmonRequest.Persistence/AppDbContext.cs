using AdmonRequest.Domain.Entitie;
using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdmonRequest.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }


        public virtual DbSet<ApprovalStage> ApprovalStages { get; set; }
        public virtual DbSet<BudgetCategory> BudgetCategories { get; set; }
        public virtual DbSet<BudgetDetail> BudgetDetails { get; set; }
        public virtual DbSet<BudgetMethod> BudgetMethods { get; set; }
        public virtual DbSet<BudgetPeriod> BudgetPeriods { get; set; }
        public virtual DbSet<BudgetTracking> BudgetTrackings { get; set; }
        public virtual DbSet<BudgetYear> BudgetYears { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentSubUnit> DepartmentSubUnits { get; set; }
        public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<StaffRecord> StaffRecords { get; set; }
        public virtual DbSet<VoteType> VoteTypes { get; set; }
        public virtual DbSet<PaymentTracking> PaymentTrackings { get; set; }
        public virtual DbSet<RequestAttachment> RequestAttachments { get; set; }
        public virtual DbSet<EmailWorker> EmailWorkers { get; set; }
        public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; }
        public virtual DbSet<StatementofAccount> StatementofAccounts { get; set; }
        public virtual DbSet<PersonRegistration> PersonRegistrations { get; set; }
        public virtual DbSet<PersonAdditionalInfo> PersonAdditionalInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
