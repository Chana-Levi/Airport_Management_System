using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BLAirlines
    {
        public int AirlineId { get; set; }

        public string AirlineName { get; set; } = null!;

        public string ContactInformation { get; set; } = null!;

        public string Website { get; set; } = null!;

        public virtual ICollection<Flight> Flights { get; set; } = new List<    Flight>();

        public virtual Worker Worker { get; set; } = null!;
    }
}
