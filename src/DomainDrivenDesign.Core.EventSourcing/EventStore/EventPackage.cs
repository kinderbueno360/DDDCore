using DomainDrivenDesign.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.EventSourcing
{
    public class EventPackage
    {
        public string Id { get; private set; }
        public Event Event { get; private set; }
        public string EventStreamId { get; private set; }
        public int EventNumber { get; private set; }
        public EventPackage(Event @event, int eventNumber, string streamStateId)
        {
            Event = @event;
            EventNumber = eventNumber;
            EventStreamId = streamStateId;
            Id = $"{streamStateId}-{EventNumber}";
        }
    }
}
