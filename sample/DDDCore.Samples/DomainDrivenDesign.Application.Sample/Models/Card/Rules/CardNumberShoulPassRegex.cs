namespace DomainDrivenDesign.Application.Sample.Models
{
    using DomainDrivenDesign.Core.Interfaces;
    using System.Text.RegularExpressions;
    public class CardNumberShoulPassRegex : IValidationRule
    {
        private readonly string _value;

        internal CardNumberShoulPassRegex(string value)
        {
            _value = value;
        }
        public string Message => "Card number was not valid";

        public bool IsBroken()
        {
            if (_value is null) return true;

            const string RegExForValidation = @"^4[0-9]{12}(?:[0-9]{3})?$";//Visa Card Regex: just for testing purpose

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(_value);

            return (!match.Success);
        }
    }
}
