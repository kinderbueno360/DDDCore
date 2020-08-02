using DomainDrivenDesign.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainDrivenDesign.Core.Models
{
    public abstract class EntityBase<T>
    {
        private readonly List<Event> _events;
        protected EntityBase() => _events = new List<Event>();
        protected void Raise(Event @event) => _events.Add(@event);
        public IEnumerable<Event> GetEvents() => _events.AsEnumerable();
        public void ClearEvents() => _events.Clear();

        public T Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }

}
