using Ardalis.Result;

namespace QuestBoard.UseCases.Contributors.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateContributorCommand(string Name, string Email, string? PhoneNumber) : Ardalis.SharedKernel.ICommand<Result<Guid>>;
