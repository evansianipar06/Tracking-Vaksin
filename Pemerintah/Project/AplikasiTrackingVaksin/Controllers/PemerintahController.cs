using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplikasiTrackingVaksin.ServiceReference1;

namespace AplikasiTrackingVaksin.Controllers
{
    public class PemerintahController : Controller
    {
        // GET: Pemerintah
        public ActionResult Index()
        {
            Service1Client obj = new Service1Client();

            return View(obj.datapenduduk());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Data_Penduduk data_Penduduk)
        {
            Service1Client obj = new Service1Client();
            obj.tambahPenduduk(data_Penduduk);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Service1Client obj = new Service1Client();
            obj.deletePenduduk(id);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Edit(int id)
        {
            Service1Client obj = new Service1Client();
            Data_Penduduk data_Penduduk = obj.GetData_PendudukById(id);
            return View(data_Penduduk);

        }
        [HttpPost]
        public ActionResult Edit(Data_Penduduk data_Penduduk)
        {
            Service1Client obj = new Service1Client();
            obj.editPenduduk(data_Penduduk);
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Service1Client obj = new Service1Client();
            Data_Penduduk data_Penduduk = obj.GetData_PendudukById(id);
            return View(data_Penduduk);

        }
    }
}