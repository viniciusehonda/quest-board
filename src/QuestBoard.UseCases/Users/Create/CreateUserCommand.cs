using Ardalis.Result;

namespace QuestBoard.UseCases;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateUserCommand(string FirstName, string LastName, string Email, string Password) : Ardalis.SharedKernel.ICommand<Result<Guid>>;