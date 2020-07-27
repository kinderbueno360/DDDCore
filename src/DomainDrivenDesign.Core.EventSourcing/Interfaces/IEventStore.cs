namespace DomainDrivenDesign.Core.EventSourcing.EventStore
{
    using DomainDrivenDesign.Core.Events;
    using System.Collections.Generic;

    public interface IEventStore
    {
        void CreateNewStream(string streamName, Event domainEvents);
        void AppendToStream(string streamName, Event @event, int? expectedVersion);

        void SubscribeToStream(string streamName, Event @event, int? expectedVersion);

        IEnumerable<Event> GetStream(string streamName, int fromVersion, int toVersion);

        void AddSnapshot<T>(string streamName, T snapshot);

        T GetLatestSnapshot<T>(string streamName) where T : class;
    }
}