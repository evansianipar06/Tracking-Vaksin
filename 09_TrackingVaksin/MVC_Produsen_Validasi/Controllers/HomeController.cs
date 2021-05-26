using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.ServiceReferenceAll;

namespace MVC_Produsen_Validasi.Controllers
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
                if (GetAkun.Role.Equals("BPOM"))
                {
                    return RedirectToAction("Index", "BPOMLaporTerima");
                }
                if (GetAkun.Role.Equals("RS"))
                {
                    return RedirectToAction("Index", "RS");
                }
                if (GetAkun.Role.Equals("Produsen"))
                {
                    return RedirectToAction("Index", "Produsen");
                }
            }
            return RedirectToAction("Index");
        }
    }
}