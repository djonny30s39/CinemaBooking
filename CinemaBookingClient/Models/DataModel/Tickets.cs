using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBookingClient.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }        

        public int AreaNumber { get; set; }

        [Required]
        public int ColumnIndex { get; set; }

        [Required]
        public int RowIndex { get; set; }
    }
}
