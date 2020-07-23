namespace DomainDrivenDesign.Core.CQRS.Interface
{
    using DomainDrivenDesign.Core.CQRS.Command;
    using DomainDrivenDesign.Core.CQRS.Query;
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMediator
    {
        Result Publish(ICommand command);
        T Publish<T>(IQuery<T> query);
    }
}
