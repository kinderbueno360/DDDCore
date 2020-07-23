namespace DomainDrivenDesign.Core.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Message 
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
