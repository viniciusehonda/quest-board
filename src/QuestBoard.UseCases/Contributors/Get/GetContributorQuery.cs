using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
