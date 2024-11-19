using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IWorkers
    {
        //מחזיר רשימה של עובדים
        public List<Worker> GetWorkersList();
        //פונקציה שמקבל עובד ומוסיפה אותו לרשימת העובדים
        public Worker AddWorker(Worker worker);
        //פונקציה שמוחקת עובד
        public Worker RemoveWorker(Worker worker);
        //פונקציה שמעדכנת 
        public Worker UpdateWorker(Worker worker);
        //פונקציה שמקבלת רשימת עובדים בתפקיד מסוים
        public List<Worker> GetWorkersByRole(string role);

    }
}
