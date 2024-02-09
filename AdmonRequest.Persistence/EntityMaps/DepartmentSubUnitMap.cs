using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class DepartmentSubUnitMap : IEntityTypeConfiguration<DepartmentSubUnit>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubUnit> builder)
        {
            builder.ToTable(nameof(DepartmentSubUnit));

            builder.HasKey(x => x.DepartmentSubUnitId);
            builder.Property(x => x.DepartmentSubUnitId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.SubUnitName).IsRequired()
                 .HasMaxLength(255);

        }
    }


}
