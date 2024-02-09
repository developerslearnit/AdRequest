using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class PaymentRequestMap : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> builder)
        {
            builder.ToTable(nameof(PaymentRequest));

            builder.HasKey(x => x.PaymentRequestId);
            builder.Property(x => x.PaymentRequestId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.RefNo).IsRequired()
                 .HasMaxLength(200);
            builder.HasIndex(x => x.SNo);
            builder.Property(x => x.SNo).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.BeneficiaryName).IsRequired()
                .HasMaxLength(400);
            builder.Property(x => x.VoteType).IsRequired(false)
              .HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired()
              .HasMaxLength(2000);
            builder.Property(x => x.Amount).IsRequired()
                .HasColumnType("decimal(18,5)");
            builder.Property(x => x.DeductionAmount).IsRequired()
                .HasColumnType("decimal(18,5)");

            builder.Property(x => x.LPONo).IsRequired(false)
           .HasMaxLength(200);

        }
    }


}
