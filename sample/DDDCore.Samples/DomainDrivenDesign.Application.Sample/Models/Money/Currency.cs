namespace DomainDrivenDesign.Application.Sample.Models
{
    using DomainDrivenDesign.Core.Models;
    using System.Collections.Generic;

    public interface ICurrencyLookup
    {
        Currency FindCurrency(string currencyCode);
    }
    public class Currency : ValueObject<Currency>
    {
        public string CurrencyCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPlaces { get; set; }

        public static Currency None = new Currency { InUse = false };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CurrencyCode;
            yield return InUse;
            yield return DecimalPlaces;
        }
    }
}
