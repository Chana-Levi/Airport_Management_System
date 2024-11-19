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
    public class BLWorkersService : IBLWorkers
    {
        IWorkers dal;
        IMapper mapper;

        public BLWorkersService(DalManager dalWorkers, IMapper m)
        {
            dal = dalWorkers.Workers;
            mapper = m;
        }
        public List<BLWorkers> BLGetWorkersByRole(string role)
        {
            var w = dal.GetWorkersByRole(role);
            return mapper.Map<List < BLWorkers >> (w);
        }
        public BLWorkers BLAddWorker(BLWorkers w)
        {
            Worker worker = mapper.Map<Worker>(w);
            dal.AddWorker(worker);
            return mapper.Map<BLWorkers>(worker);

        }

        public List<BLWorkers> BLGetWorkersList()
        {
            var w = dal.GetWorkersList();
            return mapper.Map<List<BLWorkers>>(w);
        }

        public BLWorkers BLRemoveWorker(BLWorkers w)
        {
            Worker worker = mapper.Map<Worker>(w);
            dal.RemoveWorker(worker);
            return mapper.Map<BLWorkers>(worker);
        }

        public BLWorkers BLUpdateWorker(BLWorkers w)
        {
            Worker worker = mapper.Map<Worker>(w);
            dal.UpdateWorker(worker);
            return mapper.Map<BLWorkers>(worker);
        }




    }
}
