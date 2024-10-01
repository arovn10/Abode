using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Photo
{
    public int PhotoId { get; set; }

    public int PropertyKey { get; set; }

    public string? PhotoLink { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }
}
