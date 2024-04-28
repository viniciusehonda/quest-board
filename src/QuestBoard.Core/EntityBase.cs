using System.ComponentModel.DataAnnotations.Schema;

namespace QuestBoard.Core;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    private List<DomainEventBase> _domainEvents = new List<DomainEventBase>();

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    internal void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
