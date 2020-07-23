namespace DomainDrivenDesign.Application.Sample.Command
{
    using DomainDrivenDesign.Core.CQRS.Command;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ProcessCardPaymentCommand : ICommand
    {
        public string CardNumber { get; private set; }

        public string CVV { get; private set; }

        public string ExpirationDate { get; private set; }

        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public string BeneficiaryAlias { get; private set; }

        public static Result<ProcessCardPaymentCommand> Create(string cardNumber, string cvv, string expirationDate, decimal amount, string currency, string beneficiaryAlias)
        {
            return Result.Success(new ProcessCardPaymentCommand(cardNumber, cvv, expirationDate, amount, currency, beneficiaryAlias));
        }

        private ProcessCardPaymentCommand(string cardNumber, string cvv, string expirationDate, decimal amount, string currency, string beneficiaryAlias)
        {
            CardNumber = cardNumber;
            CVV = cvv;
            ExpirationDate = expirationDate;
            Amount = amount;
            Currency = currency;
            BeneficiaryAlias = beneficiaryAlias;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
