using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class University
{
    public int UniversityId { get; set; }

    public string? School { get; set; }

    public string? UniversityLocation { get; set; }
}
