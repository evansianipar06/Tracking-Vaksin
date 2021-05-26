using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class RSLaporTerimaController : Controller
    {
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index()
        {
            List<LaporValidasiVaksin> lapList = db.LaporValidasiVaksin.Where(x => x.status == true).ToList();
            ViewBag.ListOfLaporVaksin = new SelectList(lapList, "idLapor", "namaProdusen", "deskripsi");

            List<Vaksin> vaksin = db.Vaksin.ToList();
            ViewBag.ListOfStatusVaksin = new SelectList(vaksin, "idVak", "status");
            return View();
        }

        public ActionResult IndexPantau()
        {
            List<LaporValidasiVaksin> lapList = db.LaporValidasiVaksin.Where(x => x.status == true).ToList();
            ViewBag.ListOfLaporVaksin = new SelectList(lapList, "idLapor", "namaProdusen", "deskripsi");

            List<Vaksin> vaksin = db.Vaksin.ToList();
            ViewBag.ListOfStatusVaksin = new SelectList(vaksin, "idVak", "status");
            return View();
        }

        public JsonResult GetLaporanTerimaList()
        {
            List<LaporTerimaViewModel> StuList = db.LaporTerimaVaksin.Where(x => x.status == false).Select(x => new LaporTerimaViewModel
            {
                idTer = x.idTer,
                namaProdusen = x.LaporValidasiVaksin.namaProdusen,
                pengirim = x.pengirim,
                deskripsi = x.deskripsi,
                status = x.Vaksin.status
            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaporanTerimaById(int idTer)
        {
            LaporTerimaVaksin model = db.LaporTerimaVaksin.Where(x => x.idTer == idTer).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(LaporTerimaViewModel model)
        {
            var result = false;
            try
            {
                if (model.idTer > 0)
                {
                    LaporTerimaVaksin Stu = db.LaporTerimaVaksin.SingleOrDefault(x => x.status == false && x.idTer == model.idTer);
                    Stu.idLapor = model.idLapor;
                    Stu.pengirim = model.pengirim;
                    Stu.deskripsi = model.deskripsi;
                    Stu.idVak = model.idVak;

                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    LaporTerimaVaksin Stu = new LaporTerimaVaksin();
                    Stu.idLapor = model.idLapor;
                    Stu.pengirim = model.pengirim;
                    Stu.deskripsi = model.deskripsi;
                    Stu.idVak = model.idVak;

                    Stu.status = false;
                    db.LaporTerimaVaksin.Add(Stu);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuatLaporanRecord(int idTer)
        {
            bool result = false;
            LaporTerimaVaksin Stu = db.LaporTerimaVaksin.SingleOrDefault(x => x.status == false && x.idTer == idTer);
            if (Stu != null)
            {
                Stu.status = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}