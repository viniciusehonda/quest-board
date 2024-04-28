using QuestBoard.UseCases.Contributors;
using QuestBoard.UseCases.Contributors.List;

namespace QuestBoard.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListContributorsQueryService
{
  public Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    List<ContributorDTO> result =
        [new ContributorDTO(Guid.NewGuid(), "Fake Contributor 1", "fakecontributor1@email.com", ""),
        new ContributorDTO(Guid.NewGuid(), "Fake Contributor 2", "fakecontributor2@email.com", "")];

    return Task.FromResult(result.AsEnumerable());
  }
}
