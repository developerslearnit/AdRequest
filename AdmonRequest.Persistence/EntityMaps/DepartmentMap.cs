using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));

            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.DepartmentName).IsRequired()
                 .HasMaxLength(255);
            builder.Property(x => x.ActiveStatus).IsRequired();

        }
    }


}
