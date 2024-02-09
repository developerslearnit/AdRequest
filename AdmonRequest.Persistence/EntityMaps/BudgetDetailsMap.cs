using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetDetailsMap : IEntityTypeConfiguration<BudgetDetail>
    {
        public void Configure(EntityTypeBuilder<BudgetDetail> builder)
        {
            builder.ToTable(nameof(BudgetDetail));

            builder.HasKey(x => x.BudgetDetailPeriodID);
            builder.Property(x => x.BudgetDetailPeriodID)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.AccountName).IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.AccountID).IsRequired()
              .HasMaxLength(15);
            builder.Property(x => x.BudgetAmount).IsRequired()
                .HasColumnType("decimal(18,5)");
        }
    }
}
