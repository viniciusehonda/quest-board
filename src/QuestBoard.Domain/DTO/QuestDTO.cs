using System;

namespace QuestBoard.Domain.DTO;

public class QuestDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public QuestStatus Status { get; set; }
    public QuestDifficulty Difficulty { get; set; }
    public string PublisherId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
}
