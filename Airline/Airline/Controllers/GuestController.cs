using Airline.Models;
using Airline.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Airline.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        readonly private AirlineDbContext db = new AirlineDbContext();
        [AllowAnonymous]
        public ActionResult Info(Users obj)
        {
            if (ModelState.IsValid)
            {
                bool isValid = db.User.Any(x => x.Username == obj.Username);
                if (isValid)
                { return Content("Username is already in use"); }
                db.User.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Homepage", "Login");
            }
            return Content("Failed");
        }

        public ActionResult Book(Flight fli)
        {
            Bookings model = new Bookings();
            model.Uid= fli.TempId;
            model.FlightId = fli.FlightId;
            model.From = fli.From;
            model.To = fli.To;
            model.Date = fli.Date;
            model.Type = fli.Type;
            return View(model);
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Homepage", "Login");
        }
        public ActionResult Cancel(Bookings obj)
        {
            var result = db.Booking.FirstOrDefault(b=>b.Uid==obj.Uid&&b.FlightId==obj.FlightId);
            if (result != null)
            {
                result.Flag = 1;
                db.SaveChanges();
            }
            else { return Content("Empty Result"); }
            return Content("Successfull!");
        }

        public ActionResult Bookings(Users obj)
        {
            var result = from bookings in db.Booking where bookings.Uid == obj.UsersId select bookings;
            if(result.ToList().Count==0)
            { return Content("No Bookings Found"); }
            return View(result.ToList());
        }

        public ActionResult Save(Bookings obj)
        {
            obj.Flag = 0;
            var Flight = db.Flight.FirstOrDefault(b => b.FlightId == obj.FlightId);
            Flight.Seats = Flight.Seats - obj.Seats;
            if (obj.Uid==0)
            { return Content("Null Uid"); }
            db.Booking.Add(obj);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            return RedirectToAction("Homepage","Login");
        }

        [HttpPost]
        public ActionResult Search(GuestViewModel obj)
        {   
            var result = (from flights in db.Flight where (flights.Date==obj.Search.Date&&flights.Type==obj.Search.Type) select flights);
            if (result.ToList().Count == 0)
            { return Content("no flights found"); }
            var viewmodel = new FlightViewModel()
            {
                Flight = result.ToList(),
                User = obj.Usr      
            };
            return View(viewmodel);
        }

        [AllowAnonymous]
        public ActionResult Login(Users obj)
        {
         
            if (ModelState.IsValid)
            {
                bool isValid = db.User.Any(x => x.Username == obj.Username && x.Password == obj.Password);

                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(obj.Username, false);
                    Users result = (from user in db.User where obj.Username == user.Username select user).FirstOrDefault();
            
                    var viewmodel = new GuestViewModel()
                    {
                        Usr = new Users() {UsersId=result.UsersId,Username=result.Username,Password=result.Password},
                        
                        Search = new Search() { }
                    };
                   

                    return View(viewmodel);
                }
            }
            return Content("Invalid Credentials!!");
        }
    }
}