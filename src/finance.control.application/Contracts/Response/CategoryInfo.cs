using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finance.control.application.Contracts.Response;

public readonly record struct CategoryInfo
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}
