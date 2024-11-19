using DAL;
using DAL.DalApi;
using DAL.DalModels;
using DAL.DalServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // לבצע הזרקות
    // ליצג את שכבת הדל בצורה מרוכזת
    public class DalManager
    {
        public IWorkers Workers { get; set; }
        public IFlights Flights { get; set; }
        public IFlightsCrew FlightsCrew { get; set; }
        public IAirlines Airlines { get; set; }
        public IOrders Orders { get; set; }
        public ITraveling Traveling { get; set; }

        public DalManager(string connStr)
        {
            // אוביקט שיכיל את כל מחלקות השרות
            ServiceCollection services = new ServiceCollection();
            // מוסיפים לאוסף את אוביקט ממחלקות השרות
            services.AddDbContext<FlightContext>(opt => opt.UseSqlServer(connStr));
            services.AddSingleton<IWorkers, WorkersServices>();
            services.AddSingleton<IFlights,FlightService>();
            services.AddSingleton<IFlightsCrew, FlightsCrewService>();
            services.AddSingleton<IAirlines, AirlinesServices>();
            services.AddSingleton<IOrders, OrdersServices>();
            services.AddSingleton<ITraveling, TravelingService>();
            //כל פעם שרוצים לקבל מופע מסוג עובדים צריך לגשת לאינטרפיס של העובדים 
            ServiceProvider provider = services.BuildServiceProvider();
            Workers = provider.GetService<IWorkers>();
            Airlines = provider.GetService<IAirlines>();
            Flights = provider.GetService<IFlights>();
            FlightsCrew = provider.GetService<IFlightsCrew>();
            Orders = provider.GetService<IOrders>();
            Traveling = provider.GetService<ITraveling>();
        }
    }
}

