using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        public int CinemaId { get; set; }

        //[Required]
        public DateTime OrderDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
