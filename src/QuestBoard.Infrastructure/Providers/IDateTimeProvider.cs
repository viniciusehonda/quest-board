using System;

namespace QuestBoard.Infrastructure.Providers;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
