using BL.BLModels;
using BL.BLServices;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLFlightCrew
    {
        public List<BLFlightCrew> BLGetFlightsCrewList();
        public string BLGetAirlineName(BLFlightCrew fc);
        
    }
}
