using System.ComponentModel.DataAnnotations;

namespace QuestBoard.Web.Users;

public class CreateUserRequest
{
    public const string Route = "/api/users/create";

    [Required]
    public string? FirstName {get; set;}
    [Required]
    public string? LastName {get; set;}
    [Required]
    public string? Email {get; set;}
    [Required]
    public string? Password {get; set;}
}
