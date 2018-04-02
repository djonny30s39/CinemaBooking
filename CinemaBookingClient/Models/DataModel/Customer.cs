using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBookingClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required, MaxLength(450)]
        [ForeignKey("AspNetUsers")]
        public string AspNetUsersId { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
