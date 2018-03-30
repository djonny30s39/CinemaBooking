using CinemaBookingClient.HardCode;
using CinemaBookingClient.Models;
using CinemaBookingClient.Models.DataModel;
using CinemaBookingClient.Services;
using CinemaBookingClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// pwd Aa123456!
namespace CinemaBookingClient.Controllers
{
    [Authorize]
    public class CinemaHallController : Controller
    {
        private ICinemaSeatPlanWS seatPlan;
        private ICinemaDataService dataSevice;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private string userId;

        public CinemaHallController(ICinemaSeatPlanWS seatPlan, ICinemaDataService dataSevice, UserManager<ApplicationUser> userManager)
        {
            this.seatPlan = seatPlan;
            this.dataSevice = dataSevice;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CinemaHallPlan()
        {
            var user = userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            string userId = user.Id;
            var cinemaHallVM = CinemaHallCreator.GetCinemaHallViewModel(seatPlan, dataSevice, userId);
            return View("CinemaHallPlan", cinemaHallVM);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Seats seats)
        {
            if (!ModelState.IsValid)
                return View();

            var user = userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            string userId = user.Id;
            List<Position> orderSeats = seats.Seat;
            var order = dataSevice.CreateOrder(userId, HardCodeValues.cinemaHallId, HardCodeValues.seanceId, orderSeats);

            return RedirectToAction("CinemaHallPlan");

        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public class Seats
        {
            public List<Position> Seat { get; set; }
        }
    }


}
