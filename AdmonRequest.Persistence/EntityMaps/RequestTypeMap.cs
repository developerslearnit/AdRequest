using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class RequestTypeMap : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder.ToTable(nameof(RequestType));

            builder.HasKey(x => x.RequestTypeId);
            builder.Property(x => x.RequestTypeId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.RequestTypeName).IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.ActiveStatus).IsRequired();
            builder.Property(x => x.IsProject).IsRequired();
            builder.Property(x => x.ReduceBuget).IsRequired();
            builder.Property(x => x.IsAdvance).IsRequired();
            builder.Property(x => x.IsDirectPayment).IsRequired();
        }
    }

    public class VoteTypeMap : IEntityTypeConfiguration<VoteType>
    {
        public void Configure(EntityTypeBuilder<VoteType> builder)
        {
            builder.ToTable(nameof(VoteType));

            builder.HasKey(x => x.VoteTypeId);
            builder.Property(x => x.VoteTypeId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.VoteTypeName).IsRequired()
                .HasMaxLength(255);
        }
    }


}
