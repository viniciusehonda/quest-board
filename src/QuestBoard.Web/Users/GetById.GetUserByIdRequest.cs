namespace QuestBoard.Web.Users;

public class GetUserByIdRequest
{
    public const string Route = "/Users/{UserId:guid}";
    public static string BuildRoute(Guid userId) => Route.Replace("{UserId:guid}", userId.ToString());

    public Guid UserId { get; set; }
}
