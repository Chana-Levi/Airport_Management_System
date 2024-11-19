using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class Traveling
{
    public int PassengerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ContactInfo { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
