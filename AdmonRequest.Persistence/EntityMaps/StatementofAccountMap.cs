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
    public class StatementofAccountMap : IEntityTypeConfiguration<StatementofAccount>
    {
        public void Configure(EntityTypeBuilder<StatementofAccount> builder)
        {
            builder.ToTable(nameof(StatementofAccount));

            builder.HasKey(x => x.TransactionID);
            builder.Property(x => x.TransactionID)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.AccountNo).IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Gjsource).IsRequired()
             .HasMaxLength(50);
            builder.Property(x => x.AccountName).IsRequired()
                .HasMaxLength(400);
        }
    }
}
