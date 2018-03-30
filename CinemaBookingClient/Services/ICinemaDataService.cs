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
        Order CreateOrder(string userId, int cinemaHallId, int seanceId, List<Position> seats);
        void SaveData(); 
    }
}
