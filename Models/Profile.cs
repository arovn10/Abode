using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Profile
{
    public int PropertyId { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Deposit { get; set; }

    public string? AirConditioning { get; set; }

    public string? Laundry { get; set; }

    public string? Parking { get; set; }

    public string? Photo { get; set; }

    public string? Address { get; set; }

    public int? Bedrooms { get; set; }

    public int? Bathrooms { get; set; }

    public string? LeaseTerms { get; set; }

    public string? Amenities { get; set; }

    public string? Bio { get; set; }

    public int? PhoneNumber { get; set; }

    public string? PublicEmail { get; set; }

    public virtual PropertiesDelete Property { get; set; } = null!;
}
