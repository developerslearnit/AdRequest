using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetYearMap : IEntityTypeConfiguration<BudgetYear>
    {
        public void Configure(EntityTypeBuilder<BudgetYear> builder)
        {
            builder.ToTable(nameof(BudgetYear));

            builder.HasKey(x => x.BudgetYearId);
            builder.Property(x => x.BudgetYearId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.BudgetYearName).IsRequired()
                 .HasMaxLength(255);
            builder.Property(x => x.ActiveStatus).IsRequired();

        }
    }


}
