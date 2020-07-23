namespace DomainDrivenDesign.Core.CQRS.Command
{
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Execute(Maybe<TCommand>  command);
    }
}
