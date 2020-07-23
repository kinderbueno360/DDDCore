namespace DomainDrivenDesign.Domain.Sample.Models
{
    using DomainDrivenDesign.Core.Interfaces;
    using System.Text.RegularExpressions;

    public class CCVShouldBeFourOrThreeDigit : IValidationRule
    {
        private readonly string _value;

        internal CCVShouldBeFourOrThreeDigit(string value)
        {
            _value = value;
        }

        public string Message => "CVV should be Four or Three digit";

        public bool IsBroken()
        {
            if (_value is null) return true;

            const string RegExForValidation = @"^[0-9]{3,4}$";

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(_value);

            return (!match.Success);
        }
    }
}
