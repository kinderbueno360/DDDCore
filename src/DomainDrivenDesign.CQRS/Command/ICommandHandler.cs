namespace DomainDrivenDesign.CQRS.Command
{
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Execute(TCommand command);
    }
}
