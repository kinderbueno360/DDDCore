using DomainDrivenDesign.Core.Exceptions;
using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomainDrivenDesign.Application.Sample.Models
{
    public class ExpiryDate : ValueObject<ExpiryDate>
    {
        private readonly DateTime _value;

        public ExpiryDate(string expiryDateStr)
        {
            _value = ParseExpiryDate(expiryDateStr);

            this.CheckRule(new ExpirationDateShouldBeGreaterThanDatetimeNow(_value));
        }

        private DateTime ParseExpiryDate(string input)
        {
            try
            {
                var regex = new Regex(@"(?<month>\d{2})/(?<year>\d{2})");
                var match = regex.Match(input);
                var year = int.Parse(match.Groups["year"].Value);
                var month = int.Parse(match.Groups["month"].Value);

                int expiryYear = 2000 + year;

                var lastDayOfMonth = DateTime.DaysInMonth(expiryYear, month);
                return new DateTime(expiryYear, month, lastDayOfMonth, 23, 59, 59);
            }
            catch
            {
                throw new ValueObjectException("Invalid card expiry date");
            }

        }
        public override string ToString() => _value.ToString();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public  DateTime Value => _value;
    }
}