using Ardalis.SmartEnum;

namespace QuestBoard.Core;

public class QuestStatus : SmartEnum<QuestStatus>
{
    public static readonly QuestStatus New = new(nameof(New), 1);
    public static readonly QuestStatus Closed = new(nameof(Closed), 2);

    protected QuestStatus(string name, int value) : base(name, value) { }
}
