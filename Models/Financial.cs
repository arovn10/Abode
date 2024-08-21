using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Financial
{
    public int PropertyId { get; set; }

    public string? Insurances { get; set; }

    public string? Loans { get; set; }

    public string? Purchase { get; set; }

    public virtual Property Property { get; set; } = null!;
}
