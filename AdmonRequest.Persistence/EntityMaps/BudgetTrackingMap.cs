using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class BudgetTrackingMap : IEntityTypeConfiguration<BudgetTracking>
    {
        public void Configure(EntityTypeBuilder<BudgetTracking> builder)
        {
            builder.ToTable(nameof(BudgetTracking));

            builder.HasKey(x => x.BudgetTrackingId);
            builder.Property(x => x.BudgetTrackingId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
                       
            builder.Property(x => x.Credit).IsRequired()
                .HasColumnType("decimal(18,5)");
            builder.Property(x => x.Debit).IsRequired()
               .HasColumnType("decimal(18,5)");
            builder.Property(x => x.GJSource).IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired()
                .HasMaxLength(2000);
            builder.Property(x => x.Syncronized).IsRequired();

        }
    }



}
