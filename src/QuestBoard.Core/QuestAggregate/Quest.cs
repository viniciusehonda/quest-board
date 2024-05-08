using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace QuestBoard.Core;

public class Quest(string title, string description, Guid creatorId) : EntityBase, IAggregateRoot
{
    public string Title { get; private set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string Description { get; private set; } = Guard.Against.NullOrEmpty(description, nameof(description));
    public Guid CreatorId { get; private set; } = Guard.Against.NullOrEmpty(creatorId, nameof(creatorId));
    public User? Creator { get; private set; }
    public QuestStatus Status {get; private set; } = QuestStatus.New;

    public void UpdateTitle(string newTitle)
    {
        Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
    }

    public void UpdateDescription(string newDescription)
    {
        Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
    }
}
