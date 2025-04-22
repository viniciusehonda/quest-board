namespace QuestBoard.Domain;

public class Quest
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public QuestStatus Status { get; private set; }
    public QuestDifficulty Difficulty { get; private set; }
    public string PublisherId { get; private set; } = string.Empty;
    public User? Publiser { get; private set; } = null;

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Quest(Guid id,
     string title,
      string description,
        QuestDifficulty difficulty,
         string publisherId,
         DateTime createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = QuestStatus.Draft;
        Difficulty = difficulty;
        PublisherId = publisherId;
        CreatedAt = createdAt;
    }

    public void Update(string title, string description, DateTime updatedAt)
    {
        Title = title;
        Description = description;
        UpdatedAt = updatedAt;
    }

    public void Publish()
    {
        Status = QuestStatus.Published;
    }

    public void Finish()
    {
        Status = QuestStatus.Finished;
    }

    public void Cancel()
    {
        Status = QuestStatus.Cancelled;
    }

    public static class Factory
    {
        public static Quest Create(Guid id,
        string title,
        string description,
        QuestDifficulty difficulty,
        string publisherId,
        DateTime createdAt)
        {
            return new Quest(id, title, description, difficulty, publisherId, createdAt);
        }
    }
}
