using System;
using System.ComponentModel.DataAnnotations;

namespace SeasideBliss.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }

        [Required]
        public string AccommodationType { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}

