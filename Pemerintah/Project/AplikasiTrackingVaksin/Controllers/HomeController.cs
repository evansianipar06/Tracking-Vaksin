using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplikasiTrackingVaksin.ServiceReference1;
namespace AplikasiTrackingVaksin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Username, string Password)
        {
            Service1Client service1Client = new Service1Client();
            if (service1Client.Login(Username, Password))
            {
                Login GetAkun = service1Client.GetAkun(Username);
                if (GetAkun.Role.Equals("Pemerintah"))
                {
                    return RedirectToAction("Index", "Pemerintah");
                }
                if (GetAkun.Role.Equals("Produsen"))
                {
                    return RedirectToAction("Index", "RegVaksin");
                }

            }
            return RedirectToAction("Index");
        }
    }
}