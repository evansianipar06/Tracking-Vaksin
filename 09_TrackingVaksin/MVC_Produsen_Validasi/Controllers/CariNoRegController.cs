using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Produsen_Validasi.Models;

namespace MVC_Produsen_Validasi.Controllers
{
    public class CariNoRegController : Controller
    {
        // GET: CariNoReg
        TrackingVaksinEntities db = new TrackingVaksinEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCekRegPasienList()
        {
            List<CekRegPasienViewModel> StuList = db.CekValid.Where(x => x.status == true).Select(x => new CekRegPasienViewModel
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
    }
}