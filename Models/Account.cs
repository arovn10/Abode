using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Account
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }

    public string? School { get; set; }
}
