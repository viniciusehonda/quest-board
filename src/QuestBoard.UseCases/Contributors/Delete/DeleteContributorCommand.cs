using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases.Contributors.Delete;

public record DeleteContributorCommand(Guid ContributorId) : ICommand<Result>;
