using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases.Contributors.Update;

public record UpdateContributorCommand(Guid ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
