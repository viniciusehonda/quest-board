using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestBoard.Core;
using QuestBoard.Infrastructure.Data.Config;

namespace QuestBoard.Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.Property(s => s.Email)
        .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH)
        .IsRequired();
    builder.Property(s => s.FirstName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();
    builder.Property(s => s.LastName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.OwnsOne(s => s.Password);
  }
}
