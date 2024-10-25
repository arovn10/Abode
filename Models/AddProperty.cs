using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class AddProperty
{
    public int PropertyId { get; set; }

    public string? Username { get; set; }

    public string? Address { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Bedrooms { get; set; }

    public int? Bathrooms { get; set; }

    public decimal? Price { get; set; }

    public int? SquareFeet { get; set; }

    public string? Amenities { get; set; }

    public string? LeaseTerms { get; set; }

    public string? Photo { get; set; }

    public string? School { get; set; }

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    public virtual Spec? Spec { get; set; }
}
