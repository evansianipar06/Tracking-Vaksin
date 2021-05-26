using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class BPOMPenggunaanVaksinController : Controller
    {
        // GET: BPOMPenggunaanVaksin
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index()
        {
            List<Data_Penduduk> pddkList = db.Data_Penduduk.ToList();
            ViewBag.ListOfDataPenduduk = new SelectList(pddkList, "id", "NIK");


            List<Reg_Vaksin> RegList = db.Reg_Vaksin.ToList();
            ViewBag.ListOfRegVaksin = new SelectList(RegList, "id", "kode");
            return View();
        }


        public JsonResult GetPenggunaanVaksinList()
        {
            List<PenggunaanVaksinViewModel> StuList = db.PenggunaanVaksin.Where(x => x.status == true).Select(x => new PenggunaanVaksinViewModel
            {
                idUsed = x.idUsed,
                NIK = x.Data_Penduduk.NIK,
                noRekamMedis = x.noRekamMedis,
                kode = x.Reg_Vaksin.kode

            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPenggunaanVaksinById(int idUsed)
        {
            PenggunaanVaksin model = db.PenggunaanVaksin.Where(x => x.idUsed == idUsed).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(PenggunaanVaksinViewModel model)
        {
            var result = false;
            try
            {
                if (model.idUsed > 0)
                {
                    PenggunaanVaksin Stu = db.PenggunaanVaksin.SingleOrDefault(x => x.status == false && x.idUsed == model.idUsed);
                    Stu.idPend = model.idPend;
                    Stu.noRekamMedis = model.noRekamMedis;
                    Stu.idRegVaksin = model.idRegVaksin;

                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    PenggunaanVaksin Stu = new PenggunaanVaksin();
                    Stu.idPend = model.idPend;
                    Stu.noRekamMedis = model.noRekamMedis;
                    Stu.idRegVaksin = model.idRegVaksin;

                    Stu.status = false;
                    db.PenggunaanVaksin.Add(Stu);
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

        public JsonResult BuatLaporanRecord(int idUsed)
        {
            bool result = false;
            PenggunaanVaksin Stu = db.PenggunaanVaksin.SingleOrDefault(x => x.status == false && x.idUsed == idUsed);
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