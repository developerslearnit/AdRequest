using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class StaffRecordMap : IEntityTypeConfiguration<StaffRecord>
    {
        public void Configure(EntityTypeBuilder<StaffRecord> builder)
        {
            builder.ToTable(nameof(StaffRecord));

            builder.HasKey(x => x.StaffId);
            builder.Property(x => x.StaffId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.StaffName).IsRequired()
                .HasMaxLength(355);
            builder.Property(x => x.StaffCode).IsRequired(false)
                .HasMaxLength(200);
            builder.Property(x => x.StaffCode).IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Password).IsRequired()
                 .HasMaxLength(2000);
            builder.Property(x => x.PasswordSalt).IsRequired()
                 .HasMaxLength(500);
            builder.Property(x => x.Username).IsRequired()
               .HasMaxLength(256);
            builder.Property(x => x.Email).IsRequired()
               .HasMaxLength(256);
            builder.Property(x => x.Role).IsRequired()
               .HasMaxLength(50);
        }
    }


}
