using Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airline.ViewModel
{
    public class FlightViewModel
    {
        public IEnumerable<Flight> Flight { get; set; }
        public Users User { get; set; }
    }
}