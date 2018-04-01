using CinemaBookingClient.Data;
using CinemaBookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingClient.Services
{
    public class SqlCinemaDataService : ICinemaDataService
    {
        private ApplicationDbContext context;
        public SqlCinemaDataService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CinemaHall GetCinemaHall(int cinema_id, int cinemahall_id)
        {
            CinemaHall hall = context.CinemaHalls.FirstOrDefault(c => c.CinemaId == cinema_id && c.Id == cinemahall_id); 
            return hall;
        }

        public Customer GetCustomer(string aspnetuser_id)
        {
            Customer customer = context.Customers.FirstOrDefault<Customer>(c => c.AspNetUsersId == aspnetuser_id);
            return customer;
        }

        public IEnumerable<Order> GetOrders(string aspnetuser_id)
        {
            Customer customer = GetCustomer(aspnetuser_id);
            if (customer == null)
                return null;
            //context.Entry(customer).Collection(c => c.Orders).Load();  
            var orders = context.Orders
                       .Where(b => b.CustomerId == customer.Id)
                       .Include(b => b.Seance)
                       .ThenInclude(bb => bb.CinemaHall)
                        .ThenInclude(bb => bb.Cinema)
                       .Include(b => b.Tickets)
                       .ToList();
            return orders;
        }

        public IEnumerable<Ticket> GetSeanceTickets(int seanceID)
        {
            var tickets = context.Tickets
                      .Where(b => b.Order.SeanceId == seanceID)
                      .Include(b => b.Order)
                      .ThenInclude(bb => bb.Customer)
                      .Include(b => b.Order)
                      .ThenInclude(bb => bb.Seance)  
                      .ToList();
            return tickets;
        }

        public Order CreateOrder(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> requestedSeats)
        {

            if (requestedSeats == null)
                return null;
            var seats = requestedSeats.Where(z => z != null);
            if (seats.Count() == 0)
                return null;
            HashSet<Position> toAdd = new HashSet<Position>(seats);
            var currentUser = context.Customers.FirstOrDefault(z => z.AspNetUsersId == userId);
            Order order = new Order
            {
                CustomerId = currentUser.Id,
                //CinemaHallId = cinemaHallId,
                SeanceId = seanceId,
                OrderDate = DateTime.Now
            };
            //currentUser.Orders.Add(order);
            context.Orders.Add(order);
            SaveData();

            foreach (var t in toAdd)
            {
                Ticket ticket = new Ticket
                {
                    AreaNumber = t.AreaNumber,
                    RowIndex = t.RowIndex,
                    ColumnIndex = t.ColumnIndex,
                    //CinemaHallId = cinemaHallId,
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

        public int CancelTickets(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> removeSeats)
        {
            int cnt = 0;
            if (removeSeats == null)
                return 0;
            var seats = removeSeats.Where(z => z != null);
            if (seats.Count() == 0)
                return 0;
            HashSet<Position> toRemove = new HashSet<Position>(seats);
            foreach (var pos in toRemove)
            {
                Ticket ticket = context.Tickets.FirstOrDefault(t => t.AreaNumber == pos.AreaNumber && t.ColumnIndex == pos.ColumnIndex && t.RowIndex == pos.RowIndex);
                if (ticket != null)
                {
                    context.Tickets.Remove(ticket);
                    SaveData();
                    cnt++;
                }
            }
            return cnt;
        }

        public Order RecompileOrders(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> addSeats, IEnumerable<Position> removeSeats)
        {
            var duplicates =
                addSeats.Where(p =>p!=null && removeSeats.Any(p2 => p != null && p2.AreaNumber == p.AreaNumber && p2.ColumnIndex == p.ColumnIndex && p2.RowIndex == p.RowIndex));

            var toAdd = addSeats.Where(p => !duplicates.Any(p2 => p2.AreaNumber == p.AreaNumber && p2.ColumnIndex == p.ColumnIndex && p2.RowIndex == p.RowIndex));
            var toRemove = removeSeats.Where(p => !duplicates.Any(p2 => p2.AreaNumber == p.AreaNumber && p2.ColumnIndex == p.ColumnIndex && p2.RowIndex == p.RowIndex));

            CancelTickets(userId, cinemaHallId, seanceId, toRemove);
            return CreateOrder(userId, cinemaHallId, seanceId, toAdd);
        }

        public void SaveData()
        {
            context.SaveChanges();
        }

        
    }
}
