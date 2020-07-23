namespace DomainDrivenDesign.Core.Exceptions
{
    using DomainDrivenDesign.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ValueObjectException : Exception
    {
        public IValidationRule BrokenRule { get; }

        public string Details { get; }

        public ValueObjectException(IValidationRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            this.Details = brokenRule.Message;
        }

        public ValueObjectException(string message) : base(message)
        {

        }
        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
