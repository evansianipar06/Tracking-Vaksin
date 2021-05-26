using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class CekNoRegPasienController : Controller
    {
        // GET: CekNoRegPasien
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index()
        {
            List<Data_Penduduk> pddkList = db.Data_Penduduk.ToList();
            ViewBag.ListOfDataPenduduk = new SelectList(pddkList, "id", "NIK");

            List<Vaksin> vaksin = db.Vaksin.ToList();
            ViewBag.ListOfStatusVaksin = new SelectList(vaksin, "idVak", "status");

            List<Reg_Vaksin> RegList = db.Reg_Vaksin.ToList();
            ViewBag.ListOfRegVaksin = new SelectList(RegList, "id", "kode", "jenis");
            return View();
        }

        public ActionResult IndexPantau()
        {
            List<Data_Penduduk> pddkList = db.Data_Penduduk.ToList();
            ViewBag.ListOfDataPenduduk = new SelectList(pddkList, "id", "NIK");

            List<Vaksin> vaksin = db.Vaksin.ToList();
            ViewBag.ListOfStatusVaksin = new SelectList(vaksin, "idVak", "status");

            List<Reg_Vaksin> RegList = db.Reg_Vaksin.ToList();
            ViewBag.ListOfRegVaksin = new SelectList(RegList, "id", "kode", "jenis");
            return View();
        }

        public JsonResult GetCekRegPasienList()
        {
            List<CekRegPasienViewModel> StuList = db.CekValid.Where(x => x.status == false).Select(x => new CekRegPasienViewModel
            {
                id = x.id,
                kode = x.Reg_Vaksin.kode,
                NIK = x.Data_Penduduk.NIK,
                nama = x.Data_Penduduk.nama,
                kelurahan = x.Data_Penduduk.kelurahan,
                kecamatan = x.Data_Penduduk.kelurahan,
                kota = x.Data_Penduduk.kota,
                status = x.Vaksin.status

            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCekRegPasienById(int id)
        {
            CekValid model = db.CekValid.Where(x => x.id == id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(CekRegPasienViewModel model)
        {
            var result = false;
            try
            {
                if (model.id > 0)
                {
                    CekValid Stu = db.CekValid.SingleOrDefault(x => x.status == false && x.id == model.id);
                    Stu.idRegVaksin = model.idRegVaksin;
                    Stu.idPend = model.idPend;
                    Stu.idVak = model.idVak;

                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    CekValid Stu = new CekValid();
                    Stu.idRegVaksin = model.idRegVaksin;
                    Stu.idPend = model.idPend;
                    Stu.idVak = model.idVak;
                    Stu.status = false;
                    db.CekValid.Add(Stu);
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

        public JsonResult BuatLaporanRecord(int id)
        {
            bool result = false;
            CekValid Stu = db.CekValid.SingleOrDefault(x => x.status == false && x.id == id);
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