using AutoMapper;
using BL.BLApi;
using BL.BLModels;
using DAL;
using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLServices
{
    public class BLFlightCrewService : IBLFlightCrew
    {
        IFlightsCrew dal;
        IMapper mapper;

        public BLFlightCrewService(DalManager dalFlightCrew, IMapper m)
        {
            dal = dalFlightCrew.FlightsCrew;
            mapper = m;
        }
        public List<BLFlightCrew> BLGetFlightsCrewList()
        {
            var list = dal.GetFlightsCrewList();
            var BLlist = mapper.Map<List<BLFlightCrew>>(list);
            return BLlist;
        }
        public string BLGetAirlineName(BLFlightCrew fc)
        {
            FlightCrew flightCrew = mapper.Map<FlightCrew>(fc);
            string airlineName = dal.GetAirlineName(flightCrew);
            return airlineName;
        }


    }
}