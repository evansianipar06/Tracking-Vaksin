using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class PendudukController : Controller
    {
        // GET: Penduduk
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index(string cari)
        {
            return View(db.Data_Penduduk.Where(x => x.NIK.Contains(cari) || cari == null).ToList());
        }
    }
}