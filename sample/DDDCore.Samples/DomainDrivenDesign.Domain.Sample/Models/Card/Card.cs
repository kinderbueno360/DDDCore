
namespace DomainDrivenDesign.Domain.Sample.Models
{
    using DomainDrivenDesign.Core.Models;
    using System;
    using System.Collections.Generic;

    public class Card : ValueObject<Card>
    {
        public CardNumber CardNumber { get; protected set; }

        public ExpiryDate ExpirationDate { get; protected set; }

        public CVV CVV { get; protected set; }

        public Card(CardNumber cardNumber, ExpiryDate expirationDate, CVV ccv)
        {
            this.CardNumber = cardNumber;
            this.ExpirationDate = expirationDate;
            this.CVV = ccv;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CardNumber;
            yield return ExpirationDate;
            yield return CVV;
        }
    }
}
