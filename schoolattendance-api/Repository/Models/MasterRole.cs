using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class MasterRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<MasterUser> MasterUsers { get; set; } = new List<MasterUser>();
}
