namespace DomainDrivenDesign.Application.Sample.Models
{
    using DomainDrivenDesign.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CurrencyShouldBeSpecified : IValidationRule
    {
        private readonly string _value;

        internal CurrencyShouldBeSpecified(string value)
        {
            this._value = value;
        }

        public string Message => "Currency code must be specified";

        public bool IsBroken()
        {
            return (string.IsNullOrEmpty(_value));
        }
    }
}
