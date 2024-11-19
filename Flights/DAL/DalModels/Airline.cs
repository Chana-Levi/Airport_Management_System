using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class Airline
{
    public int AirlineId { get; set; }

    public string AirlineName { get; set; }

    public string ContactInformation { get; set; }

    public string Website { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
