namespace DomainDrivenDesign.Core.Interfaces
{
    using DomainDrivenDesign.Core.Events;
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMediator
    {
        Result Raise(Event @event);
    }
}
