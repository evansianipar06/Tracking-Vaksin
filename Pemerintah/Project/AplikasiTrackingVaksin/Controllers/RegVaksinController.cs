using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplikasiTrackingVaksin.ServiceReference1;

namespace AplikasiTrackingVaksin.Controllers
{
    public class RegVaksinController : Controller
    {
        // GET: RegVaksin
        public ActionResult Index()
        {
            Service1Client service = new Service1Client();
            return View(service.dataRegVaksin());
        }

        [HttpGet]
        public ActionResult Tambah()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tambah(Reg_Vaksin regVaksin)
        {
            Service1Client service = new Service1Client();
            service.tambahRegVaksin(regVaksin);
            return RedirectToAction("Index");
        }

        public ActionResult Hapus(int id)
        {
            Service1Client service = new Service1Client();
            service.hapusRegVaksin(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Service1Client service = new Service1Client();
            Reg_Vaksin dataRegVaksin = service.getDataRegVaksinById(id);
            return View(dataRegVaksin);
        }

        [HttpPost]
        public ActionResult Edit(Reg_Vaksin regVaksin)
        {
            Service1Client service = new Service1Client();
            service.editRegVaksin(regVaksin);
            return RedirectToAction("Index");
        }
    }
}