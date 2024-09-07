using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class LeaseAgreement
{
    public int LeaseId { get; set; }

    public int? TenantId { get; set; }

    public int? PropertyId { get; set; }

    public DateOnly? LeaseStartDate { get; set; }

    public DateOnly? LeaseEndDate { get; set; }

    public string? LeaseTerms { get; set; }

    public decimal? MonthlyRent { get; set; }

    public decimal? Deposit { get; set; }

    public string? Status { get; set; }

    public virtual PropertiesDelete? Property { get; set; }

    public virtual TenantsOld? Tenant { get; set; }
}
