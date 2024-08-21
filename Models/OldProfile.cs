using System;
using System.Collections.Generic;

namespace Abode.Models;

public partial class OldProfile
{
    public int UserId { get; set; }

    public string? UserTypeId { get; set; }

    public string? FirstName { get; set; }

    public string? NamePreferred { get; set; }

    public string? MiddleName { get; set; }

    public string ProfilePic { get; set; } = null!;

    public string? Pronouns { get; set; }

    public string? LoginName { get; set; }

    public string? LastName { get; set; }

    public string? LoginPassword { get; set; }

    public string AuthToken { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
