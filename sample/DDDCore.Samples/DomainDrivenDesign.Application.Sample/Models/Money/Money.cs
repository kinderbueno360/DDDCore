namespace DomainDrivenDesign.Application.Sample.Models
{
    using DomainDrivenDesign.Core.Models;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Money : ValueObject<Money>
    {

        protected Money(Decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
        {
            this.CheckRule(new CurrencyShouldBeSpecified(currencyCode));
            this.CheckRule(new AmountShouldBePositive(amount));

            var currency = currencyLookup.FindCurrency(currencyCode);

            this.CheckRule(new CurrencySouldBeInUse(currencyCode, currency.InUse));
            this.CheckRule(new AmountShouldBeDecimalPlacesLessThanCurrencypublic(amount, currency.DecimalPlaces, currencyCode));

            this.Amount = amount;
            this.Currency = currency;
        }

        protected Money(Decimal amount, Currency currency)
        {
            this.CheckRule(new AmountShouldBePositive(amount));

            this.Amount = amount;
            this.Currency = currency;
        }

        public Result<Money> Add(Money moneyAdd)
        {
            if (moneyAdd.Currency != Currency)
                return Result.Fail<Money>("Different Corrency");

            return Result.Success(new Money(Amount + moneyAdd.Amount, Currency));
        }

        public Result<Money> Subtract(Money moneyAdd)
        {
            if (moneyAdd.Currency != Currency)
                return Result.Fail<Money>("Different Corrency");

            return Result.Success(new Money(Amount - moneyAdd.Amount, Currency));
        }

        public static Money FromDecimal(
            decimal amount,
            string currency,
            ICurrencyLookup currencyLookup)
            => new Money(amount, currency, currencyLookup);

        public static Money FromString(
            string amount,
            string currency,
            ICurrencyLookup currencyLookup)
            => new Money(decimal.Parse(amount), currency, currencyLookup);

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2).Value;

        public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend).Value;

        public decimal ToDecimal()
         => Amount;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public Decimal Amount { get; }

        public Currency Currency { get; }
    }
}
