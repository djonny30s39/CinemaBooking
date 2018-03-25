using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Cinema_Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
