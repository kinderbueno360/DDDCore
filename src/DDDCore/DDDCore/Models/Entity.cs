namespace DomainDrivenDesign.Core.Models
{
    using DomainDrivenDesign.Core.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Entity : EntityBase<Guid>
    {
        private readonly List<Event> _events;
        protected Entity() => _events = new List<Event>();
        protected void Raise(Event @event) => _events.Add(@event);
        public IEnumerable<Event> GetChanges() => _events.AsEnumerable();
        public void ClearChanges() => _events.Clear();

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}
