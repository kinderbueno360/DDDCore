using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; private set; }

        public Guid CorrelationId { get; private set; }

        public Guid CausationId { get; private set; }

        protected Event(Guid correlationId, Guid causationId)
        {
            CausationId = causationId;
            CorrelationId = correlationId;
            Timestamp = DateTime.Now;
        }
    }
}
