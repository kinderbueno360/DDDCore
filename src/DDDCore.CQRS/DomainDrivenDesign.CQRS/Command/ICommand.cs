using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.CQRS.Command
{
    public interface ICommand
    {
        bool IsValid();
    }
}
