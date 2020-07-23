namespace DomainDrivenDesign.Domain.Sample.Models
{
    using DomainDrivenDesign.Core.Interfaces;
    using System;

    public class AmountShouldBeDecimalPlacesLessThanCurrencypublic : IValidationRule
    {
        private readonly Decimal _value;

        private readonly int _decimalPlaces;

        private readonly string _currencyCode;

        internal AmountShouldBeDecimalPlacesLessThanCurrencypublic(Decimal value, int decimalPlaces, string currencyCode)
        {
            this._value = value;
            this._decimalPlaces = decimalPlaces;
            this._currencyCode = currencyCode;
        }

        public string Message => $"Amount in {_currencyCode} cannot have more than {_decimalPlaces} decimals";

        public bool IsBroken()
        {
            return ((decimal.Round(_value, _decimalPlaces) != _value));
        }
    }
}
