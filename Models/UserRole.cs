using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class UserRole
{
    public string UserTypeId { get; set; } = null!;

    public string? UserRoleName { get; set; }
}
