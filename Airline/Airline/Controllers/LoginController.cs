using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airline.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
    }
}