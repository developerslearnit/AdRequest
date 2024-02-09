using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetCatMap : IEntityTypeConfiguration<BudgetCategory>
    {
        public void Configure(EntityTypeBuilder<BudgetCategory> builder)
        {
            builder.ToTable(nameof(BudgetCategory));

            builder.HasKey(x => x.BudgetCategoryId);
            builder.Property(x => x.BudgetCategoryId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.BudgetCategoryName).IsRequired()
                .HasMaxLength(255);
        }
    }

    //




}
