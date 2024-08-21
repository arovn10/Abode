using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Utility
{
    public int PropertyId { get; set; }

    public string? MaintenanceRequestsAssignee { get; set; }

    public string? Responsibility { get; set; }

    public string? UtilityProviders { get; set; }

    public virtual Property Property { get; set; } = null!;
}
