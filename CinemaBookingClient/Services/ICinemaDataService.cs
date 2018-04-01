using CinemaBookingClient.Models;
using CinemaBookingClient.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Services
{
    public interface ICinemaDataService
    {
        CinemaHall GetCinemaHall(int cinema_id, int cinemahall_id);
        Customer GetCustomer(string aspnetuser_id);
        IEnumerable<Order> GetOrders(string aspnetuser_id);
        Order CreateOrder(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> requestedSeats);
        int CancelTickets(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> removeSeats);
        void SaveData();
        Customer CreateCustomer(string id);

        /// <summary>
        /// Returns new order if any created
        /// </summary> 
        Order RecompileOrders(string userId, int cinemaHallId, int seanceId, IEnumerable<Position> addSeats, IEnumerable<Position> removeSeats);
        IEnumerable<Ticket> GetSeanceTickets(int value);
    }
}
