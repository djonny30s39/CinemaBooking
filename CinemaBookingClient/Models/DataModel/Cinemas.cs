using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        public ICollection<CinemaHall> CinemaHalls { get; set; }

        public string Address { get; set; }
    }
}
