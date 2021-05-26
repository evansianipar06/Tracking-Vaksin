using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<PenggunaanVaksin> dataPenggunaan()
        {
            TrackingVaksinEntities trackingVaksinEntities = new TrackingVaksinEntities();
            var penduduk = from x in trackingVaksinEntities.PenggunaanVaksin select x;
            return penduduk.ToList<PenggunaanVaksin>();
        }

        //Autentikasi
        public bool Login(string Username, string Password)
        {
            TrackingVaksinEntities tracking = new TrackingVaksinEntities();
            Login GetAkun = tracking.Login.FirstOrDefault(x => x.Username.Equals(Username) && x.Passsword.Equals(Password));
            
            if (GetAkun != null)
            {
                tracking.Dispose();
                return true;
            }
            return false;
        }

        public Login GetAkun(string Username)
        {
            TrackingVaksinEntities tracking = new TrackingVaksinEntities();
            Login GetAkun = tracking.Login.FirstOrDefault(x => x.Username.Equals(Username));
            tracking.Dispose();
            return GetAkun;
        }

        public Login auth(Login data)
        {
            TrackingVaksinEntities tracking = new TrackingVaksinEntities();
            int jlh = tracking.Login.Count();
            tracking.Login.Add(data);
            int jlh2 = tracking.Login.Count();
            if (jlh2 > jlh)
            {
                return data;
            }
            return null;
        }

        //LaporRegVaksin
        public bool TambahLaporanVaksin(LaporValidasiVaksin data)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            if (data != null)
            {
                db.LaporValidasiVaksin.Add(data);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {
                db.Dispose();
                return false;
            }
        }

        public bool UpdateLaporanVaksin(LaporValidasiVaksin data)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            LaporValidasiVaksin newData = db.LaporValidasiVaksin.FirstOrDefault(x => x.idLapor.Equals(data.idLapor));
            if (data != null)
            {
                newData.namaProdusen = data.namaProdusen;
                newData.deskripsi = data.deskripsi;
                newData.status = data.status;
                newData.id = data.id;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }

        public bool DeleteLaporanVaksin(int idLapor)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            LaporValidasiVaksin data = db.LaporValidasiVaksin.FirstOrDefault(x => x.idLapor.Equals(idLapor));
            if (data != null)
            {
                db.LaporValidasiVaksin.Remove(data);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }
        public LaporValidasiVaksin dataLaporan(int idLapor)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            LaporValidasiVaksin lapor = db.LaporValidasiVaksin.FirstOrDefault(x => x.idLapor == idLapor);
            db.Dispose();
            return lapor;
        }

        //Penggunaan Vaksin
        public bool TambahPenggunaanVaksin(PenggunaanVaksin data)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            if (data != null)
            {
                db.PenggunaanVaksin.Add(data);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {
                db.Dispose();
                return false;
            }
        }

        public bool UpdatePenggunaanVaksin(PenggunaanVaksin data)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            PenggunaanVaksin newData = db.PenggunaanVaksin.FirstOrDefault(x => x.idUsed.Equals(data.idUsed));
            if (data != null)
            {
                newData.noRekamMedis = data.noRekamMedis;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }

        public bool DeletePenggunaanVaksin(int idUsed)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            PenggunaanVaksin data = db.PenggunaanVaksin.FirstOrDefault(x => x.idUsed.Equals(idUsed));
            if (data != null)
            {
                db.PenggunaanVaksin.Remove(data);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }
    }
}
