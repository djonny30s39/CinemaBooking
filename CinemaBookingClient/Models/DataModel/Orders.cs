using CinemaBookingClient.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        public int SeanceId { get; set; } 
        public Seance Seance { get; set; }

        //[Required]
        public DateTime OrderDate { get; set; }        

        public ICollection<Ticket> Tickets { get; set; }
    }
}
