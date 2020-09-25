using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airline.Models
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext() : base("name=AirlineDbContext") { }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Bookings> Booking { get; set; }

        public DbSet<Search> Search { get; set; }
        
    }
}