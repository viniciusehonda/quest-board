using Ardalis.SharedKernel;

namespace QuestBoard.Core.ContributorAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class ContributorDeletedEvent(Guid contributorId) : DomainEventBase
{
  public Guid ContributorId { get; init; } = contributorId;
}
