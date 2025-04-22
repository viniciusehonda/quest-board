using System;
using QuestBoard.Infrastructure.Providers;

namespace QuestBoard.UnitTests.Mocks;

public class MockDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => new DateTime(2025, 04, 20, 20, 0, 0, DateTimeKind.Local);

    public DateTime UtcNow => new DateTime(2025, 04, 20, 23, 0, 0, DateTimeKind.Utc);
}
