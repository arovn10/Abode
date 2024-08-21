using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class RentalListing
{
    public int ListingId { get; set; }

    public string? PropertyName { get; set; }

    public string? Address { get; set; }

    public decimal? MonthlyRent { get; set; }

    public DateOnly? AvailableDate { get; set; }
}
