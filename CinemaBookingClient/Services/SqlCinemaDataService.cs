using CinemaBookingClient.Data;
using CinemaBookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBookingClient.Services
{
    public class SqlCinemaDataService :ICinemaDataService
    {
        private ApplicationDbContext context;
        public SqlCinemaDataService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CinemaHall GetCinemaHall(int cinema_id, int cinemahall_id)
        {
            CinemaHall hall = context.CinemaHalls.FirstOrDefault(c => c.CinemaId == cinema_id && c.Id == cinemahall_id);
            if (hall != null)
            { 
                context.Entry(hall).Collection(h => h.Tickets).Load();
                foreach (var ticket in hall.Tickets)
                {
                    context.Entry(ticket).Reference(t => t.Order).Load();
                    context.Entry(ticket.Order).Reference(z => z.Customer).Load();
                } 
            }
            return hall;
        }

        public Customer GetCustomer(string aspnetuser_id)
        {
            Customer customer = context.Customers.FirstOrDefault<Customer>(c => c.AspNetUsersId == aspnetuser_id);
            return customer;
        }

        public Order CreateOrder(string userId, int cinemaHallId, int seanceId, List<Position> requestedSeats)
        {
            if (requestedSeats == null)
                return null;
            var seats = requestedSeats.Where(z => z != null);
            if (seats.Count() == 0)
                return null;
            var currentUser = context.Customers.FirstOrDefault(z=> z.AspNetUsersId == userId);
            Order order = new Order
            {
                CustomerId = currentUser.Id,
                CinemaHallId = cinemaHallId,
                SeanceId = seanceId,
                OrderDate = DateTime.Now
            };
            //currentUser.Orders.Add(order);
            context.Orders.Add(order);
            SaveData();

            foreach (var t in seats )
            {
                Ticket ticket = new Ticket
                {
                    AreaNumber = t.AreaNumber,
                    RowIndex = t.RowIndex,
                    ColumnIndex = t.ColumnIndex,
                    CinemaHallId = cinemaHallId,
                    OrderId = order.Id                    
                };
                context.Tickets.Add(ticket);  
                order.Tickets.Add(ticket);                
            }
            SaveData();

            return order;
        }

        public Customer CreateCustomer(string id)
        {
            var customer = new Customer
            {
                AspNetUsersId = id
            };
            context.Customers.Add(customer);
            SaveData();
            return customer;
        }

        public void SaveData()
        {
            context.SaveChanges();
        }

        public Order RemoveSeats(string userId, int cinemaHallId, int seanceId, List<Position> rejectedSeats)
        {
            throw new NotImplementedException();
        }
    }
}
