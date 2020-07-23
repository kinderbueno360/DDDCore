namespace DomainDrivenDesign.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Entity : EntityBase<Guid>
    {
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
