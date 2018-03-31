using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required, MaxLength(450)]
        [ForeignKey("AspNetUsers")]
        public string AspNetUsersId { get; set; }

    }
}
