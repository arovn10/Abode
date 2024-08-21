using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Landlord
{
    public int LandlordId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Phone { get; set; }
}
