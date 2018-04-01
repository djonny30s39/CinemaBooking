using CinemaBookingClient.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        //[ForeignKey("CinemaHall")]
        //public int CinemaHallId { get; set; }
        
        //public CinemaHall CinemaHall { get; set; }
        
        public int SeanceId { get; set; } 
        public Seance Seance { get; set; }

        //[Required]
        public DateTime OrderDate { get; set; }        

        public ICollection<Ticket> Tickets { get; set; }
    }
}
