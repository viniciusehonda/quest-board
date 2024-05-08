using Ardalis.Specification;

namespace QuestBoard.Core;

public class QuestByIdSpec : Specification<Quest>
{
    public QuestByIdSpec(Guid questId)
    {
        Query
            .Where(quest => quest.Id == questId);
    }
}
