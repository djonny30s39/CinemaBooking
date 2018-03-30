using CinemaBookingClient.Data;
using CinemaBookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Services
{
    public class SqlCinemaDataService :ICinemaDataService
    {
        private ApplicationDbContext _context;
        public SqlCinemaDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public CinemaHall GetCinemaHall(int cinema_id, int cinemahall_id)
        {
            CinemaHall hall = _context.CinemaHalls.FirstOrDefault(c => c.CinemaId == cinema_id && c.Id == cinemahall_id);
            if (hall != null)
            { 
                _context.Entry(hall).Collection(h => h.Tickets).Load();
                foreach (var ticket in hall.Tickets)
                {
                    _context.Entry(ticket).Reference(t => t.Order).Load();
                    _context.Entry(ticket.Order).Reference(z => z.Customer).Load();
                } 
            }
            return hall;
        }

        public Customer GetCustomer(string aspnetuser_id)
        {
            Customer customer = _context.Customers.FirstOrDefault<Customer>(c => c.AspNetUsers_Id == aspnetuser_id);
            return customer;
        }

        public void SaveData()
        {
            _context.SaveChanges();
        }
    }
}
