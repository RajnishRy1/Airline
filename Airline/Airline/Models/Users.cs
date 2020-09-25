using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airline.Models
{
    public class Users
    {
        [Key]
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}