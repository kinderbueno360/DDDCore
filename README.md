# DDDCore

This is a Framework designed to give us the Core of DDD to .Net. This Framework is using .Net Standard 2.


## Articles about this Framework

[How to Build a good one Value Object](https://medium.com/@carlosbueno.kinder/how-to-building-a-good-one-value-object-57b1c7d2c5f0).


## Installation

You can install using nuget Package Manager

```
Install-Package DomainDrivenDesign.Core -Version 0.1.3
```

```
Install-Package DomainDrivenDesign.Core.CQRS -Version 0.0.1
```


Or using .Net Cli


```
dotnet add package DomainDrivenDesign.Core --version 0.1.3
```

```
dotnet add package DomainDrivenDesign.Core.CQRS --version 0.0.1
```

## Technologies used:

- Railway.NetCore

## Usage

You can use Value Object like this one:

*Money* 

```csharp
    using DomainDrivenDesign.Core.Models;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Money : ValueObject<Money>
    {

        protected Money(Decimal amount, string currencyCode)
        {
            this.CheckRule(new CurrencyShouldBeSpecified(currencyCode));

            this.Amount = amount;
            this.Currency = currency;
        }

        protected Money(Decimal amount, Currency currency)
        {
            this.CheckRule(new AmountShouldBePositive(amount));

            this.Amount = amount;
            this.Currency = currency;
        }

   
        public static Money FromDecimal(
            decimal amount,
            string currency)
            => new Money(amount, currency);


        public decimal ToDecimal()
         => Amount;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public Decimal Amount { get; }

        public String Currency { get; }
    }
```
*CurrencyShouldBeSpecified.cs*

```csharp
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
```


Also, you can use Entity Object.

*Payment.cs* Entity Sample

```csharp
    using DomainDrivenDesign.Core.Models;
    using Railway.NetCore.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Payment : Entity
    {

        public Card Card { get; protected set; }

        public Money Amount { get; protected set; }

        public string BeneficiaryAlias { get; protected set; }


        public DateTime CreatedOn { get; protected set; }


        public static Result<Payment> CreateNewCardPayment(Card card, Money amount, string beneficiaryAlias)
        {
            return Result.Success(new Payment(card, amount, beneficiaryAlias));
        }


        private Payment(Card card, Money amount, string beneficiaryAlias) : base()
        {
            this.Card = card;
            this.Amount = amount;
            this.BeneficiaryAlias = beneficiaryAlias;
            this.CreatedOn = DateTime.Now;
        }
    }
```
Soon Mediator, Command, Query and Handlers samples.
If you wish you can see this samples on Sample Project.

## License

MIT
