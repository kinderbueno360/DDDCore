using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.CQRS.Query
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
    }
}
