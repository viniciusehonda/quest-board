using Ardalis.Specification;

namespace QuestBoard.Core.ContributorAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
