namespace QuestBoard.Domain;

public class User
{
    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public List<Quest> PublisedQuests { get; set; } = new();

    private User(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public static class Factory
    {
        public static User Create(string id, string name, string email)
        {
            return new User(id, name, email);
        }
    }
}
