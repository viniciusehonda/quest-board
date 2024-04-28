namespace QuestBoard.Web.Contributors;

public record DeleteContributorRequest
{
  public const string Route = "/Contributors/{ContributorId:string}";
  public static string BuildRoute(Guid contributorId) => Route.Replace("{ContributorId:string}", contributorId.ToString());

  public Guid ContributorId { get; set; }
}
