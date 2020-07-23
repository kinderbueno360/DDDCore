namespace DDDCore.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IValidationRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
