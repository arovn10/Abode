using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class ShowingAttendee
{
    public int ShowingId { get; set; }

    public int? UserId { get; set; }

    public string? Notes { get; set; }

    public int AttendeeId { get; set; }

    public virtual ShowingScheduler Showing { get; set; } = null!;

    public virtual Account? User { get; set; }
}
