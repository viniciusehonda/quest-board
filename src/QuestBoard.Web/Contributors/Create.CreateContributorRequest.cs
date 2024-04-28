using System.ComponentModel.DataAnnotations;

namespace QuestBoard.Web.Contributors;

public class CreateContributorRequest
{
  public const string Route = "/Contributors";

  [Required]
  public string? Name { get; set; }
  [Required]
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}
