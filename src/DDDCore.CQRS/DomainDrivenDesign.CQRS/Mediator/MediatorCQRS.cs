namespace DomainDrivenDesign.Core.CQRS
{
    using DomainDrivenDesign.Core.CQRS.Command;
    using DomainDrivenDesign.Core.CQRS.Interface;
    using DomainDrivenDesign.Core.CQRS.Query;
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;

    public class MediatorCQRS : Mediator , IMediatorCQRS
    {
        private readonly IServiceProvider _provider;

        public MediatorCQRS(IServiceProvider provider) : base(provider)
        {
            _provider = provider;
        }

        public Result Publish(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Execute((dynamic)command);

            return result;
        }


        public T Publish<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Get((dynamic)query);

            return result;
        }
    }
}
