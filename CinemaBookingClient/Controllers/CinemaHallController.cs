using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBookingClient.Models;
using CinemaBookingClient.Services;
using CinemaBookingClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaBookingClient.Controllers
{    
    public class CinemaHallController : Controller
    {
        private ICinemaSeatPlanWS seatPlan;
        

        public CinemaHallController(ICinemaSeatPlanWS seatPlan)
        {
            this.seatPlan = seatPlan;
        }
        
        [HttpGet]
        public IActionResult CinemaHallPlan()
        {     
            var cinemaHallVM = CinemaHallCreator.GetCinemaHallViewModel(seatPlan);
            return View("CinemaHallPlan", cinemaHallVM);
        }

  
    }
}
