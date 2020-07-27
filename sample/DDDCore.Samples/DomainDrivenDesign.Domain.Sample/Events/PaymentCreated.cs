using DomainDrivenDesign.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Domain.Sample.Events
{
    public class PaymentCreated : Event
    {
        public PaymentCreated() : base(Guid.NewGuid(), Guid.NewGuid()) 
        { }
    }
}
