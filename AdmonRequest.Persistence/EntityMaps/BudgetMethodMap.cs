using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetMethodMap : IEntityTypeConfiguration<BudgetMethod>
    {
        public void Configure(EntityTypeBuilder<BudgetMethod> builder)
        {
            builder.ToTable(nameof(BudgetMethod));

            builder.HasKey(x => x.BudgetMethodId);
            builder.Property(x => x.BudgetMethodId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.BudgetMethodName).IsRequired()
                .HasMaxLength(300);
            
        }
    }
}
