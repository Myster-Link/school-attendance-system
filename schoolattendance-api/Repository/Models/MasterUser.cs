using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class MasterUser
{
    public string UserId { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual MasterRole Role { get; set; } = null!;
}
