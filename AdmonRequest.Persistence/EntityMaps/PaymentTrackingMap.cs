using AdmonRequest.Domain.Entitie;
using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class PaymentTrackingMap : IEntityTypeConfiguration<PaymentTracking>
    {
        public void Configure(EntityTypeBuilder<PaymentTracking> builder)
        {
            builder.ToTable(nameof(PaymentTracking));

            builder.HasKey(x => x.TrackingId);
            builder.Property(x => x.TrackingId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.OtherRefno).IsRequired()
                 .HasMaxLength(200);
            builder.HasIndex(x => x.SNo);
            builder.Property(x => x.SNo).IsRequired()
                .ValueGeneratedOnAdd();
           
        }
    }
}
