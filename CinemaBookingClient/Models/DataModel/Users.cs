using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Users
    {        
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public int AspNetUsers_Id { get; set; }
    }
}
