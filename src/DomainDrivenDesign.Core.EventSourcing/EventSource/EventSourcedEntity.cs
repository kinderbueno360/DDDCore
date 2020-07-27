namespace DomainDrivenDesign.Core.EventSourcing.EventSource
{
    using DomainDrivenDesign.Core.Events;
    using DomainDrivenDesign.Core.Models;

    public abstract class EventSourcedEntity : Entity
    {
        public int Version { get; protected set; }

        public abstract void Apply(Event @event);
    }
}
