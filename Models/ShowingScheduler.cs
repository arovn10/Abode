using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class ShowingScheduler
{
    public int ShowingId { get; set; }

    public int PropertyId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool PublicShowing { get; set; }

    public virtual ICollection<Account> Users { get; set; } = new List<Account>();
}
