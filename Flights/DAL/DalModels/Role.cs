using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleType { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
