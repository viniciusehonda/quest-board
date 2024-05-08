using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestBoard.Core;
using QuestBoard.Infrastructure.Data.Config;

namespace QuestBoard.Infrastructure.Data.Config;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Value,
                x => QuestStatus.FromValue(x));

        builder.HasOne(x => x.Creator)
            .WithMany(x => x.CreatedQuests)
            .HasForeignKey(x => x.CreatorId);
    }
}
