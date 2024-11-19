using BL.BLModels;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLAirlines
    {
        public List<BLAirlines> BLRead();
        public List<string> BLReturnAllTheAirlinesName();
        public BLAirlines BLAddAirline(BLAirlines airline);
        public string BLChangeContactInfo(BLAirlines airline);
        public BLAirlines BLDeleteAirline(int id);

    }
}
