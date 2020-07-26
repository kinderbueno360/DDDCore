namespace DomainDrivenDesign.Domain.Sample.Models
{
    using DomainDrivenDesign.Core.Models;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Payment : Entity
    {

        public string CardNumber { get; protected set; }

        public string CVV { get; protected set; }

        public string ExpirationDate { get; protected set; }

        public decimal Amount { get; protected set; }

        public string BeneficiaryAlias { get; protected set; }

        public DateTime CreatedOn { get; protected set; }

        public string CardHint => $"{CardNumber.Substring(0, 6)}XXXXXX{CardNumber.Substring(12, CardNumber.Length - 12)}";

        private Payment(string cardNumber, string cvv, DateTime expirationDate, decimal amount, string beneficiaryAlias) : base()
        {

             if (cardNumber is null) 
             {
                return throw ValidationException("Card number was not valid");
             }
             
            Regex regex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");//Visa Card Regex: just for testing purpose
            Match match = regex.Match(cardNumber);

            if(!match.Success)
            {
                return throw ValidationException("Card number was not valid");
            }
            
            Regex regex = new Regex(@"^[0-9]{3,4}$");
            match = regex.Match(cvv);

            if(!match.Success)
            {
                return throw ValidationException("CVV should be Four or Three digit");
            }

            Regex regex = new Regex(@"^[0-9]{3,4}$");
            match = regex.Match(cvv);

            if(!match.Success)
            {
                return throw ValidationException("CVV should be Four or Three digit");
            }

            if (expirationDate < DateTime.Now)
            {
                return throw ValidationException("Invalid card expiration date");
            }

            // Many Validations here and those validations don't belong to Payment
            this.CardNumber = cardNumber;
            this.CVV = cvv;
            this.ExpirationDate = expirationDate;
            this.Amount = amount;
            this.BeneficiaryAlias = beneficiaryAlias;
            this.CreatedOn = DateTime.Now;
        }
    }
}
