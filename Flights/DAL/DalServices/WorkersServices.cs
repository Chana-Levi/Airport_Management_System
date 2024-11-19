using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class WorkersServices : IWorkers
    {
        FlightContext _WorkersContext;
        public WorkersServices(FlightContext workersContext)
        {
            _WorkersContext = workersContext;

        }
        //פונקציה שמקבלת רשימת עובדים בתפקיד מסוים
        public List<Worker> GetWorkersByRole(string role)
        {
            return _WorkersContext.Workers.Where(w => w.Role.RoleType == role).ToList();
        }

        public List<Worker> GetWorkersList()
        {
            return _WorkersContext.Workers.ToList();
        }
        //פונקציה שמוסיפה עובד לרשימת העובדים
        public Worker AddWorker(Worker worker)
        {
            _WorkersContext.Workers.Add(worker);
            _WorkersContext.SaveChanges();
            return worker;
        }

        public Worker RemoveWorker(Worker worker)
        {
            _WorkersContext.Workers.Remove(worker);
            _WorkersContext.SaveChanges();
            return _WorkersContext.Workers.FirstOrDefault();
        }

        public Worker UpdateWorker(Worker worker)
        {
            var workers = _WorkersContext.Workers.FirstOrDefault(worker => worker.WorkerId.Equals(worker.WorkerId));
            if (workers == null) { return null; }
            workers.WorkerId = worker.WorkerId;
            workers.LastName = worker.LastName;
            workers.FirstName = worker.FirstName;
            workers.ContactInfo = worker.ContactInfo;
            workers.DateOfEmployment = worker.DateOfEmployment;
            _WorkersContext.SaveChanges();
            return workers;
        }



    }
}



