namespace QuestBoard.Domain;

public class User
{
    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public List<Quest> PublisedQuests { get; set; } = new();

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private User(string id, string name, string email, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = createdAt;
    }

    public static class Factory
    {
        public static User Create(string id, string name, string email, DateTime createdAt)
        {
            return new User(id, name, email, createdAt);
        }
    }
}
