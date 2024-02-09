using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class PersonAdditionalInfoMap : IEntityTypeConfiguration<PersonAdditionalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonAdditionalInfo> builder)
        {
            builder.ToTable(nameof(PersonAdditionalInfo));

            builder.HasKey(x => x.PersonAdditionalInfoId);
            builder.Property(x => x.PersonAdditionalInfoId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
       
            builder.Property(x => x.TitleName).IsRequired()
                .HasMaxLength(400);
            builder.Property(x => x.Email).IsRequired()
              .HasMaxLength(200);
            builder.Property(x => x.Address).IsRequired()
              .HasMaxLength(2000);
            builder.Property(x => x.Phone).IsRequired()
 .HasMaxLength(50);
     

        }
    }
}

