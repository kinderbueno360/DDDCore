namespace DomainDrivenDesign.Application.Sample.Command
{
    using DomainDrivenDesign.Core.CQRS.Command;
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

        public Result Execute(Maybe<ProcessCardPaymentCommand> command)
        {
            return command
                    .ToResult(ProcessCardPaymentCommandShouldNotBeEmpty)
                    .OnSuccess(_command => Payment.CreateNewCardPayment
                                                        (
                                                            new Card(new CardNumber(_command.CardNumber), new ExpiryDate(_command.ExpirationDate), new CVV(_command.CVV)),
                                                            Money.FromDecimal(_command.Amount, _command.Currency, null),
                                                            _command.BeneficiaryAlias
                                                        )
                    )
                    .OnBoth(result => result);


        }
    }
}
