using Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Airline.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        readonly private string Usrname = "Rajnish";
        readonly private string Psword = "Rajnish@123";
        public AirlineDbContext db = new AirlineDbContext();

        [AllowAnonymous]
        public ActionResult Authorize(Admins admin)
        {
            if ((Usrname == admin.Username) && (Psword == admin.Password))
            {
                FormsAuthentication.SetAuthCookie(admin.Username, false);
                return RedirectToAction("Index");
            }
            return Content("Invalid Credentials!");
        }
        
        public ActionResult Index()
        {
            return View(db.Booking.ToList());
        }

        public ActionResult Pending()
        {
            return View(db.Booking.ToList());
        }
        public ActionResult Approve(Bookings obj)
        {
            var result = db.Booking.FirstOrDefault(b => b.Uid == obj.Uid&&b.FlightId==obj.FlightId);
            if (result != null)
            {
                var flight = db.Flight.FirstOrDefault(b => b.FlightId == obj.FlightId);
                flight.Seats += obj.Seats;
                result.Flag = 2;
                db.SaveChanges();
            }
            else { return Content("Empty Result"); }
            return RedirectToAction("Index");
        }
        public ActionResult Reject(Bookings obj)
        {
            var result = db.Booking.FirstOrDefault(b => b.Uid == obj.Uid && b.FlightId == obj.FlightId);
            if (result != null)
            {
                result.Flag = 4;
                db.SaveChanges();
            }
            else { return Content("Empty Result"); }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Homepage", "Login");
        }
        public ActionResult Flights()
        {
            return View(db.Flight.ToList());
        }


        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Flight obj)
        {
            if(ModelState.IsValid)
            {
                db.Flight.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = db.Flight.FirstOrDefault(b => b.FlightId == id);
            return View(model);
        }
        public ActionResult EditConfirm(Flight obj)
        {
            var model = db.Flight.FirstOrDefault(b => b.FlightId == obj.FlightId);
            if(model==null)
            { return Content("Null Id"); }
            model.From = obj.From;
            model.To = obj.To;
            model.Date = obj.Date;
            model.Time = obj.Time;
            model.Seats = obj.Seats;
            model.Type = obj.Type;
            db.SaveChanges();
            return RedirectToAction("Flights");
            
        }
        public ActionResult Delete(int id)
        {
            var result = db.Flight.FirstOrDefault(b=>b.FlightId == id);
            if (result == null)
            {
                return Content("Null Id");
            }
            db.Flight.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Flights");
        }
    }
}