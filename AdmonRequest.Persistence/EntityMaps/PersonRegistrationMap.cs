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
    public class PersonRegistrationMap : IEntityTypeConfiguration<PersonRegistration>
    {
        public void Configure(EntityTypeBuilder<PersonRegistration> builder)
        {
            builder.ToTable(nameof(PersonRegistration));

            builder.HasKey(x => x.PersonRegistrationId);
            builder.Property(x => x.PersonRegistrationId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.PersonRegistrationNo).IsRequired()
                 .HasMaxLength(200);
            builder.HasIndex(x => x.SNo);
            builder.Property(x => x.SNo).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.PersonName).IsRequired()
                .HasMaxLength(400);
            builder.Property(x => x.Email).IsRequired()
              .HasMaxLength(200);
            builder.Property(x => x.Address).IsRequired()
              .HasMaxLength(2000);
                      builder.Property(x => x.Phone).IsRequired()
           .HasMaxLength(50);
            builder.Property(x => x.Nationality).IsRequired(false)
       .HasMaxLength(50);

        }
    }
}
