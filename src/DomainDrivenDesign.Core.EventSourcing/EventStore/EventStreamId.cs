using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.EventSourcing
{
    public class EventStreamId : ValueObject<EventStreamId>
    {
        public string Id { get; private set; }
        private EventStreamId() { }
        public EventStreamId(string id)
        {
            Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
