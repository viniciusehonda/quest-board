namespace QuestBoard.Web.Users;

public class UpdateUserResponse(UserRecord user)
{
    public UserRecord User { get; set; } = user;
}
