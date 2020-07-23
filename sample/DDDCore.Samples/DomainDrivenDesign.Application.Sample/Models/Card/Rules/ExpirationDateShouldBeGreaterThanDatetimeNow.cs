namespace DomainDrivenDesign.Application.Sample.Models
{
    using DomainDrivenDesign.Core.Interfaces;
    using System;
    public class ExpirationDateShouldBeGreaterThanDatetimeNow : IValidationRule
    {
        private readonly DateTime _value;

        internal ExpirationDateShouldBeGreaterThanDatetimeNow(DateTime value)
        {
            this._value = value;
        }

        public string Message => "Invalid card expiration date";

        public bool IsBroken()
        {
            return (!(_value >= DateTime.Now));
        }
    }
}
