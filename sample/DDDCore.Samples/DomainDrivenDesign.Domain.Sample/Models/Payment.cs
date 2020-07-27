namespace DomainDrivenDesign.Domain.Sample.Models
{
    using DomainDrivenDesign.Core.Models;
    using DomainDrivenDesign.Domain.Sample.Events;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Payment : Entity
    {

        public Card Card { get; protected set; }

        public Money Amount { get; protected set; }

        public string BeneficiaryAlias { get; protected set; }


        public DateTime CreatedOn { get; protected set; }


        public static Result<Payment> CreateNewCardPayment(Card card, Money amount, string beneficiaryAlias)
        {
            return Result.Success(new Payment(card, amount, beneficiaryAlias));
        }


        private Payment(Card card, Money amount, string beneficiaryAlias) : base()
        {
            this.Card = card;
            this.Amount = amount;
            this.BeneficiaryAlias = beneficiaryAlias;
            this.CreatedOn = DateTime.Now;
            Raise(new PaymentCreated());
        }
    }
}