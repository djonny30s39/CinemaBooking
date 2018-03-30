using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class CinemaHall
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [Required]
        public string Schema_Url { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
