using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class TenantsOld
{
    public int TenantId { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? PropertyId { get; set; }

    public DateOnly? LeaseStartDate { get; set; }

    public DateOnly? LeaseEndDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<LeaseAgreement> LeaseAgreements { get; set; } = new List<LeaseAgreement>();

    public virtual Property? Property { get; set; }
}
