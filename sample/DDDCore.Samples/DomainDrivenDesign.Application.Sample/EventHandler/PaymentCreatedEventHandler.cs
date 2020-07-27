using DomainDrivenDesign.Core.Events;
using DomainDrivenDesign.Domain.Sample.Events;
using Railway.NetCore.Core;
using Railway.NetCore.Core.Maybe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Sample.EventHandler
{
    public class PaymentCreatedEventHandler : IEventHandler<PaymentCreated>
    {
        public Task  Handler(Maybe<PaymentCreated> @event)
        {
            return Task.FromResult(true);
        }
    }
}
