using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdmonRequest.Persistence.EntityMaps
{
    public class ApprovalStageMap : IEntityTypeConfiguration<ApprovalStage>
    {
        public void Configure(EntityTypeBuilder<ApprovalStage> builder)
        {
            builder.ToTable(nameof(ApprovalStage));

            builder.HasKey(x => x.ApprovalStageId);
            builder.Property(x => x.ApprovalStageId)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(x => x.StageName).IsRequired()
                .HasMaxLength(200);
        }
    }







}
