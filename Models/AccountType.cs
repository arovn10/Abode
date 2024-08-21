using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class AccountType
{
    public int AccountTypeId { get; set; }

    public string UserType { get; set; } = null!;
}
