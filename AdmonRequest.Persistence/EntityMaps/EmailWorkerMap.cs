using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class EmailWorkerMap : IEntityTypeConfiguration<EmailWorker>
    {
        public void Configure(EntityTypeBuilder<EmailWorker> builder)
        {
            builder.ToTable(nameof(EmailWorker));

            builder.HasKey(x => x.EmailWorkerId);
            builder.Property(x => x.EmailWorkerId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.ToAddress).IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.FromAddress).IsRequired()
               .HasMaxLength(500);
            builder.Property(x => x.Subject).IsRequired()
               .HasMaxLength(255);
            builder.Property(x => x.Body).IsRequired()
               .HasColumnType("text");
            builder.Property(x => x.DueDate)
               .IsRequired()
               .HasDefaultValueSql("getdate()");
            builder.Property(x => x.SentStatus).IsRequired();
        }
    }

    //




}
