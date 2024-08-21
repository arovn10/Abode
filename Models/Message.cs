using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public int? PropertyId { get; set; }

    public string? LandlordUsername { get; set; }

    public string? TenantUsername { get; set; }

    public string? Messages { get; set; }

    public DateTime? DateTime { get; set; }

    public string? StudentUsername { get; set; }
}
