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

    public interface IEventHandler<TEvent>
        where TEvent : Event
    {
        Result Handler(Maybe<TEvent> @event);
    }
}
