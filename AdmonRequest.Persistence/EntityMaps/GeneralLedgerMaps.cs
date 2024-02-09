using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class GeneralLedgerMaps : IEntityTypeConfiguration<GeneralLedger>
    {
        public void Configure(EntityTypeBuilder<GeneralLedger> builder)
        {
            builder.ToTable(nameof(GeneralLedger));

            builder.HasKey(x => x.TransactionID);
            builder.Property(x => x.TransactionID)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.Accountid).IsRequired()
                .HasMaxLength(25);
            builder.Property(x => x.Gjsource).IsRequired()
             .HasMaxLength(50);
            builder.Property(x => x.AccountName).IsRequired()
                .HasMaxLength(400);
        }
    }
}
