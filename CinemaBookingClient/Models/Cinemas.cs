using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Cinemas
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }
    }
}
