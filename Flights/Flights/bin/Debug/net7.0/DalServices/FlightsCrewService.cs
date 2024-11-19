using DAL.DalApi;
using DAL.DalModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class FlightsCrewService : IFlightsCrew
    {
        FlightContext _FlightCrewsContext;
        public FlightsCrewService(FlightContext flightsCrewContext)
        {
            _FlightCrewsContext = flightsCrewContext;

        }

        //פונקציה שמחזירה את כל רשימת הנוסעים  
        public List<FlightCrew> GetFlightsCrewList()
        {
            return _FlightCrewsContext.FlightCrews.ToList();
        }
        //פונקציה שמקבלת צוות טיסה ומחזירה באיזה חברת תעופה הוא עובד
        public string GetAirlineName(FlightCrew fc)
        {
            var flightCrew = _FlightCrewsContext.FlightCrews
                .Include(fc => fc.Flight)
                    .ThenInclude(f => f.Airline)
                .FirstOrDefault(f => f.FlightId == fc.FlightId);

            return flightCrew?.Flight?.Airline?.AirlineName;
        }


    }
}
