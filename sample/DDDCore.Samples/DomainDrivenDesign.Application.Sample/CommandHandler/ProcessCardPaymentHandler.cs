namespace DomainDrivenDesign.Application.Sample.Command
{
    using DomainDrivenDesign.Core.CQRS.Command;
    using DomainDrivenDesign.Core.CQRS.Interface;
    using DomainDrivenDesign.Core.Events;
    using DomainDrivenDesign.Core.Interfaces;
    using DomainDrivenDesign.Domain.Sample.DomainServices;
    using DomainDrivenDesign.Domain.Sample.Models;
    using Railway.NetCore.Core;
    using Railway.NetCore.Core.Maybe;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;

    public class ProcessCardPaymentCommandHandler : ICommandHandler<ProcessCardPaymentCommand>
    {
        public const string ProcessCardPaymentCommandShouldNotBeEmpty = "ProcessCardPaymentCommand should not be empty";

        protected IMediatorCQRS _mediator;

        public ProcessCardPaymentCommandHandler(IMediatorCQRS mediator)
        {
            _mediator = mediator;
        }

        public Result Execute(Maybe<ProcessCardPaymentCommand> command)
        {
            return command
                    .ToResult(ProcessCardPaymentCommandShouldNotBeEmpty)
                    .OnSuccess(_command => Payment.CreateNewCardPayment
                                                        (
                                                            new Card(new CardNumber(_command.CardNumber), new ExpiryDate(_command.ExpirationDate), new CVV(_command.CVV)),
                                                            Money.FromDecimal(_command.Amount, _command.Currency, new CurrencyLookup()),
                                                            _command.BeneficiaryAlias
                                                        ).OnSuccess(results=> 
                                                            {
                                                                foreach (Event _event in results.GetEvents())
                                                                {
                                                                    _mediator.Raise(_event);
                                                                }
                                                            })
                    )
                    .OnBoth(result => result);


        }

    }
}
