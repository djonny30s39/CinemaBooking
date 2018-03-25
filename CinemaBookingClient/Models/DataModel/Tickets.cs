using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class Tickets
    {
        public int Id { get; set; }

        [Required]
        public int Order_Id { get; set; }

        [Required]
        public int CinemaHall_Id { get; set; }
        
        public string AreaNumber { get; set; }

        [Required]
        public int ColumnIndex { get; set; }

        [Required]
        public int RowIndex { get; set; }
    }
}
