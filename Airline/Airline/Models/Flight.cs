using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airline.Models
{
    public class Flight
    {
        [Key]
       public int FlightId { get; set; }
       public string From { get; set; }
       public string To { get; set; }
       public string Date { get; set; }
       public string Time { get; set; }
       public int Seats { get; set; }
       public string Type { get; set; }
       public int TempId { get; set; }
    }
}