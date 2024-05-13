using Ardalis.Specification;

namespace QuestBoard.Core;

public class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(Guid userId)
    {
        Query
            .Where(user => user.Id == userId);
    }
}
