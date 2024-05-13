using System.ComponentModel.DataAnnotations;

namespace QuestBoard.Web.Users;

public class UpdateUserRequest
{
    public const string Route = "/Users/{UserId:guid}";
    public static string BuildRoute(Guid userId) => Route.Replace("{UserId: guid}", userId.ToString());

    public Guid UserId { get; set; }

    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Email { get; set; }
}
