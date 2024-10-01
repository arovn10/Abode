using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class PropertiesDelete
{
    public int PropertyId { get; set; }

    public string? Address { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Bedrooms { get; set; }

    public double? Bathrooms { get; set; }

    public decimal? Price { get; set; }

    public int? SquareFeet { get; set; }

    public string? Amenities { get; set; }

    public string? LeaseTerms { get; set; }

    public string? School { get; set; }

    public decimal? Deposit { get; set; }

    public string? AirConditioning { get; set; }

    public string? Laundry { get; set; }

    public string? Parking { get; set; }

    public string? Keys { get; set; }

    public string? Paint { get; set; }

    public string? Door { get; set; }

    public string? Flooring { get; set; }

    public string? Insurances { get; set; }

    public string? Loans { get; set; }

    public string? Purchase { get; set; }

    public string? MaintenanceRequestsAssignee { get; set; }

    public string? Responsibility { get; set; }

    public string? UtilityProviders { get; set; }

    public virtual Financial? Financial { get; set; }

    public virtual ICollection<LeaseAgreement> LeaseAgreements { get; set; } = new List<LeaseAgreement>();

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<TenantsOld> TenantsOlds { get; set; } = new List<TenantsOld>();

    public virtual Utility? Utility { get; set; }
}
