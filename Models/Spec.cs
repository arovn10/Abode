using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Spec
{
    public int PropertyId { get; set; }

    public string? Keys { get; set; }

    public string? Paint { get; set; }

    public string? Door { get; set; }

    public string? Flooring { get; set; }

    public int? SquareFeet { get; set; }

    public virtual AddProperty Property { get; set; } = null!;
}
