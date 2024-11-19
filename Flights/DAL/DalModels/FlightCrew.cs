using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class FlightCrew
{
    public int TeamId { get; set; }

    public int FlightId { get; set; }

    public virtual Flight Flight { get; set; }
}
