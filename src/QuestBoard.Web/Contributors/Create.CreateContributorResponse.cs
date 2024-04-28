namespace QuestBoard.Web.Contributors;

public class CreateContributorResponse(Guid id, string name, string email)
{
  public Guid Id { get; set; } = id;
  public string Name { get; set; } = name;
  public string Email { get; set; } = email;
}
