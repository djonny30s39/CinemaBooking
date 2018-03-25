using CinemaBookingClient.Models;
using System.Threading.Tasks;

namespace CinemaBookingClient.Services
{
    public interface ICinemaSeatPlanWS
    {
        Task<CinemaSeatPlan> GetCinemaSeatPlanAsync();
    }
}