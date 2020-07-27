namespace DomainDrivenDesign.Core.EventSourcing
{
    using DomainDrivenDesign.Core.Events;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EventStream
    {
        public EventStreamId EventStreamId { get; private set; } 
        public int Version { get; private set; }
        private EventStream() { }
        public EventStream(EventStreamId eventStreamId)
        {
            EventStreamId = eventStreamId;
            Version = 0;
        }
        public EventPackage Register(Event @event)
        {
            Version++;
            return new EventPackage(@event, Version, EventStreamId.Id);
        }
    }
}
