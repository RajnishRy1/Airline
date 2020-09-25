using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airline.Models
{
    public class Bookings
    {
        public int Uid { get; set; }
        public int FlightId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public int Seats { get; set; }
        public string Type { get; set; }
        public int Flag { get; set; }
        [Key]
        public int UserId { get; set; }

    }
}