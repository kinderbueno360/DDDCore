namespace DomainDrivenDesign.Core.Interfaces
{
    using DomainDrivenDesign.Core.Events;
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMediator
    {
        Task Raise(Event @event);
    }
}
