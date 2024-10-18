using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Amenity
{
    public bool FullyFurnished { get; set; }

    public bool Pool { get; set; }

    public bool PowderRoom { get; set; }

    public bool Driveway { get; set; }

    public bool LaundryUnit { get; set; }

    public bool CentralAc { get; set; }

    public bool Backyard { get; set; }

    public bool Fireplace { get; set; }

    public bool PetFriendly { get; set; }

    public int PropertyId { get; set; }

    public int AmenityId { get; set; }
}
