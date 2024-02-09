using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetPeriodMap : IEntityTypeConfiguration<BudgetPeriod>
    {
        public void Configure(EntityTypeBuilder<BudgetPeriod> builder)
        {
            builder.ToTable(nameof(BudgetPeriod));

            builder.HasKey(x => x.BudgetPeriodId);
            builder.Property(x => x.BudgetPeriodId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.BudgetPeriodName).IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.OrderNo).IsRequired();
            builder.Property(x => x.ActiveStatus).IsRequired();
            builder.Property(x => x.Open).IsRequired();

        }
    }
}
