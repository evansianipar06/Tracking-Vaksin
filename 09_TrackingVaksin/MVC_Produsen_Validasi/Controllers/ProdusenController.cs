using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class ProdusenController : Controller
    {
        // GET: Produsen
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index()
        {
            List<Reg_Vaksin> RegList = db.Reg_Vaksin.ToList();
            ViewBag.ListOfRegVaksin = new SelectList(RegList, "id", "kode", "jenis");
            return View();
        }

        public ActionResult IndexPantau()
        {
            List<Reg_Vaksin> RegList = db.Reg_Vaksin.ToList();
            ViewBag.ListOfRegVaksin = new SelectList(RegList, "id", "kode", "jenis");
            return View();
        }

        public JsonResult GetLaporanList()
        {
            List<LaporViewModel> StuList = db.LaporValidasiVaksin.Where(x => x.status == false).Select(x => new LaporViewModel
            {
                idLapor = x.idLapor,
                namaProdusen = x.namaProdusen,
                deskripsi = x.deskripsi,
                kode = x.Reg_Vaksin.kode
            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaporanById(int idLapor)
        {
            LaporValidasiVaksin model = db.LaporValidasiVaksin.Where(x => x.idLapor == idLapor).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(LaporViewModel model)
        {
            var result = false;
            try
            {
                if (model.idLapor > 0)
                {
                    LaporValidasiVaksin Stu = db.LaporValidasiVaksin.SingleOrDefault(x => x.status == false && x.idLapor == model.idLapor);
                    Stu.namaProdusen = model.namaProdusen;
                    Stu.deskripsi = model.deskripsi;
                    Stu.id = model.id;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    LaporValidasiVaksin Stu = new LaporValidasiVaksin();
                    Stu.namaProdusen = model.namaProdusen;
                    Stu.deskripsi = model.deskripsi;
                    Stu.id = model.id;

                    Stu.status = false;
                    db.LaporValidasiVaksin.Add(Stu);
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

        public JsonResult BuatLaporanRecord(int idLapor)
        {
            bool result = false;
            LaporValidasiVaksin Stu = db.LaporValidasiVaksin.SingleOrDefault(x => x.status == false && x.idLapor == idLapor);
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