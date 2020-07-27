using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.Events
{
 
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEventHandler<TEvent>
        where TEvent : Event
    {
        Task Handler(Maybe<TEvent> @event);
    }
}
