using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class RequestAttachmentMap : IEntityTypeConfiguration<RequestAttachment>
    {
        public void Configure(EntityTypeBuilder<RequestAttachment> builder)
        {
            builder.ToTable(nameof(RequestAttachment));

            builder.HasKey(x => x.RequestAttachmentId);
            builder.Property(x => x.RequestAttachmentId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.FileExt).IsRequired()
                .HasMaxLength(6);
        }
    }

    


}
