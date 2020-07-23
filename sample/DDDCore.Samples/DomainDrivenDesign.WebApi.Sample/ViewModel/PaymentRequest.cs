using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesign.WebApi.Sample.ViewModel
{
    public class PaymentRequest
    {
        /// <summary>
        /// Card
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [Required]
        public string Currency { get; set; }

        /// <summary>
        /// Beneficiary Alias
        /// </summary>
        [Required]
        public string BeneficiaryAlias { get; set; }
    }

    public class Card
    {
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// Card Expiration Date
        /// </summary>
        [Required]
        public string ExpirationDate { get; set; }

        /// <summary
        /// CVV
        /// </summary>
        [Required]
        public string CVV { get; set; }
    }
}
