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
    public class BLTravelingService : IBLTraveling
    {
        ITraveling dal;
        IMapper mapper;

        public BLTravelingService(DalManager dalTraveling, IMapper m)
        {
            dal = dalTraveling.Traveling;
            mapper = m;
        }

        public List<BLTraveling> BLGetTravelingList()
        {
            var t = dal.GetTravelingList();
            return mapper.Map<List<BLTraveling>>(t);
        }


        public BLTraveling BLAddTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.AddTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);

        }

        public BLTraveling BLUpdateTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.UpdateTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);
            
        }

        public BLTraveling BLDeleteTraveling(BLTraveling t)
        {
            Traveling traveling = mapper.Map<Traveling>(t);
            dal.DeleteTraveling(traveling);
            return mapper.Map<BLTraveling>(traveling);

        }
    }
}
