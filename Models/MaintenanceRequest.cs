using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class MaintenanceRequest
{
    public int RequestId { get; set; }

    public string? RequestDescription { get; set; }

    public string? RequestStatus { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public int? PropertyId { get; set; }

    public int? TenantId { get; set; }

    public virtual AddProperty? Property { get; set; }

    public virtual Tenant? Tenant { get; set; }
}
