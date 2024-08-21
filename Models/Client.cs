using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class Client
{
    public string AccountTypeId { get; set; } = null!;

    public string? UserType { get; set; }
}
