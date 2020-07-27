namespace DomainDrivenDesign.Core
{
    using DomainDrivenDesign.Core.Events;
    using DomainDrivenDesign.Core.Interfaces;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mediator : IMediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Raise(Event @event)
        {
            Type type = typeof(IEventHandler<>);
            Type[] typeArgs = { @event.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handler((dynamic)@event);

            return result;
        }
    }
}
