﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Core.CQRS.Query
{
    public interface IQuery<out TResponse> { }
}
