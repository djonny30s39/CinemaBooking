using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBookingClient.Models.DataModel
{
    public class Seance
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("CinemaHall")]
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Time { get; set; }        
    }
}
