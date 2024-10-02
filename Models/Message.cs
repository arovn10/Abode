using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Message
{
    public int? PropertyId { get; set; }

    public string? Sender { get; set; }

    public string? Messages { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Sendee { get; set; }

    public int MessageId { get; set; }
}
