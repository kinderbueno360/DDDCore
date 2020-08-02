using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.Tests.Base.Model
{
    public class Payment : EntityString
    {

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Amount { get; set; }

        public string BeneficiaryAlias { get; set; }

        public DateTime CreatedOn { get; set; }

        public Payment(string id, string cardNumber, string cvv, DateTime expirationDate, decimal amount, string beneficiaryAlias) : base()
        {
            this.Id = id;
            this.CardNumber = cardNumber;
            this.CVV = cvv;
            this.ExpirationDate = expirationDate;
            this.Amount = amount;
            this.BeneficiaryAlias = beneficiaryAlias;
            this.CreatedOn = DateTime.Now;
        }

    }
}
