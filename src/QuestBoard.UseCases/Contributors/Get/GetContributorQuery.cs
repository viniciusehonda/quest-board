using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases.Contributors.Get;

public record GetContributorQuery(Guid ContributorId) : IQuery<Result<ContributorDTO>>;
