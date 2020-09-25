using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airline.Models
{
    public class Search
    {
       [Key]
       public int Id { get; set; }
       public string Type { get; set; }
       public string Date { get; set; }
    }
}