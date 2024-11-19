using DAL.DalApi;
using DAL.DalModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DAL.DalServices
{
    internal class AirlinesServices : IAirlines
    {
        FlightContext _AirlinesContext;
        public AirlinesServices(FlightContext airlinesContext)
        {
            _AirlinesContext = airlinesContext;
        }

        public List<Airline> Read()
        {
            var list = _AirlinesContext.Airlines.ToList();
            Console.WriteLine("DAL Data: " + string.Join(", ", list.Select(l => l.AirlineName)));
            return list;
        }

        //public List<string> ReturnAllTheAirlinesName()
        //{
        //    return _AirlinesContext.Airlines
        //        .Select(al => al.AirlineName)
        //        .ToList();
        //}
        public List<Airline> ReturnAllTheAirlinesName()
        {
            return _AirlinesContext.Airlines.ToList();
        }

        public Airline AddAirline(Airline airline)
        {
            _AirlinesContext.Airlines.Add(airline);
            _AirlinesContext.SaveChanges();
            return airline;
        }
        
        public string ChangeContactInfo(Airline airline)
        {
            var ar = _AirlinesContext.Airlines.FirstOrDefault(a => a.AirlineId == airline.AirlineId);
            if (ar == null) { return null; }
            ar.ContactInformation = airline.ContactInformation;
            return ar.ContactInformation;
        }

        public Airline DeleteAirline(int id)
        {
            var da = _AirlinesContext.Airlines.FirstOrDefault(da => da.AirlineId == id);
            if (da == null) { return null; };
            _AirlinesContext.Airlines.Remove(da);
            _AirlinesContext.SaveChanges() ;
            return da; 
        }
    }

}
