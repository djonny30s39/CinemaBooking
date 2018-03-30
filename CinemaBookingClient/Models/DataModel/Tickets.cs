using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }


        [Required]
        public int CinemaHallId { get; set; }
        [Required]
        public CinemaHall CinemaHall { get; set; }

        public string AreaNumber { get; set; }

        [Required]
        public int ColumnIndex { get; set; }

        [Required]
        public int RowIndex { get; set; }
    }
}
