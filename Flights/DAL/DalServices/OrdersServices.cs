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
    internal class OrdersServices : IOrders
    {
        FlightContext _OrdersContext;
        public OrdersServices(FlightContext ordersContext)
        {
            _OrdersContext = ordersContext;

        }
        //פונקציה שמחזירה רשימה של כל פרטי ההזמנות
        public List<Order> GetOrdersList()
        {
            return _OrdersContext.Orders.ToList();
        }
        //פונקציה שמחזירה רשימה של טיסות ביום מסוים
        public List<Order> GetOrdersListOfDate(DateTime date)
        {
            // כוללים את הניווט לטבלה Flights
            return _OrdersContext.Orders
                .Include(o => o.Flight)
                .Where(or => or.Flight.DepartureTime.Date == date.Date) // משווים את תאריך היציאה לתאריך המבוקש
                .ToList();
        }

        //פונקציה שמוסיפה הזמנה לרשימת ההמנות
        public Order AddNewOrder(Order order)
        {
            // לבדוק את זה!!
            var newOrder = _OrdersContext.Orders.Add(order).Entity;
            _OrdersContext.SaveChanges();
            return newOrder;
        }

        public Order DeleteOrder(Order order)
        {
            var orders = _OrdersContext.Orders
            .FirstOrDefault(o => o.OrderId == order.OrderId);
            if (orders == null) { return null; }
            _OrdersContext.Orders.Remove(orders);
            _OrdersContext.SaveChanges();
            return order;
        }
        public Order UpdateOrder(Order order)
        {
            var or = _OrdersContext.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (or == null) { return null; }
            or.SeatNumber = order.SeatNumber;
            _OrdersContext.SaveChanges();
            return order;
        }

    }

}
