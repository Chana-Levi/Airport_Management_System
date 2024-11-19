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
    internal class RoleServices : IRole
    {
        FlightContext _AirlinesContext;
        public RoleServices(FlightContext airlinesContext)
        {
            _AirlinesContext = airlinesContext;
        }

        public List<IRole> avaliableAttendantList()
        {
            throw new NotImplementedException();
        }

        public List<IRole> pilotsList()
        {
            throw new NotImplementedException();
        }
        //תיקוןןןןן
        //public List<IRole> pilotsList()
        //{
        //    return _AirlinesContext.Roles
        //        .Include(p=>p.FlightCrews.)
        //        .ToList();
        //} 
        //public List<IRole> avaliableAttendantList()
        //{
        //    return _AirlinesContext.Roles
        //         .Where(pilot => pilot.פנוי == true)
        //         .Include()
        //         .ToList();

        //}

    }
}
