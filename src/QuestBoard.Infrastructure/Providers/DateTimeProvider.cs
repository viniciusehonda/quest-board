using System;

namespace QuestBoard.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime Now => DateTime.Now;

  public DateTime UtcNow => DateTime.UtcNow;
}
