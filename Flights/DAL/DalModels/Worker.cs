using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class Worker
{
    public int WorkerId { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string ContactInfo { get; set; }

    public DateTime DateOfEmployment { get; set; }

    public int AirlineId { get; set; }

    public int? RoleId { get; set; }

    public virtual Airline Airline { get; set; }

    public virtual Role Role { get; set; }
}
