using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Photo
{
    public int PropertyKey { get; set; }

    public string PhotoLink { get; set; } = null!;

    public string? Description { get; set; }

    public int PhotoId { get; set; }
}
