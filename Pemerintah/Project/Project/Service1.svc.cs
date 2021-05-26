using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
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

        //Pemerintah
        public List<Data_Penduduk> datapenduduk()
        {
            TrackingVaksinEntities trackingVaksinEntities = new TrackingVaksinEntities();
            var penduduk = from x in trackingVaksinEntities.Data_Penduduk select x;
            return penduduk.ToList<Data_Penduduk>();
        }

        public bool deletePenduduk(int id)
        {
            TrackingVaksinEntities trackingVaksinEntities = new TrackingVaksinEntities();
            Data_Penduduk delete = trackingVaksinEntities.Data_Penduduk.SingleOrDefault(x => x.id == id);
            trackingVaksinEntities.Data_Penduduk.Remove(delete);
            trackingVaksinEntities.SaveChanges();
            return true;
        }

        public bool editPenduduk(Data_Penduduk data_Penduduk)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            Data_Penduduk newData = db.Data_Penduduk.FirstOrDefault(x => x.id.Equals(data_Penduduk.id));
            if (data_Penduduk != null)
            {
                newData.NIK = data_Penduduk.NIK;
                newData.nama = data_Penduduk.nama;
                newData.kecamatan = data_Penduduk.kecamatan;
                newData.kelurahan = data_Penduduk.kelurahan;
                newData.kota = data_Penduduk.kota;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;

        }

        public Data_Penduduk GetData_PendudukById(int id)
        {
            TrackingVaksinEntities trackingVaksinEntities = new TrackingVaksinEntities();
            Data_Penduduk data_Penduduk = trackingVaksinEntities.Data_Penduduk.SingleOrDefault(x => x.id == id);
            return data_Penduduk;
        }

        public bool getPenduduk(Data_Penduduk data_Penduduk)
        {
            throw new NotImplementedException();
        }

        public bool tambahPenduduk(Data_Penduduk datapenduduk)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            if (datapenduduk != null)
            {
                db.Data_Penduduk.Add(datapenduduk);
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


        //Reg Vaksin
        public List<Reg_Vaksin> dataRegVaksin()
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            var regVaksin = from x in db.Reg_Vaksin select x;
            return regVaksin.ToList<Reg_Vaksin>();
        }

        public bool tambahRegVaksin(Reg_Vaksin regVaksin)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            if (regVaksin != null)
            {
                db.Reg_Vaksin.Add(regVaksin);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            else
            {
                db.Dispose();
                return false;
            }
            /*TrackingVaksinEntities db = new TrackingVaksinEntities();
            db.Reg_Vaksin.Add(regVaksin);
            db.SaveChanges();
            return true;*/
        }

        public bool hapusRegVaksin(int id)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            Reg_Vaksin hapus = db.Reg_Vaksin.SingleOrDefault(x => x.id == id);
            db.Reg_Vaksin.Remove(hapus);
            db.SaveChanges();
            return true;
        }

        public bool editRegVaksin(Reg_Vaksin regVaksin)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            Reg_Vaksin newData = db.Reg_Vaksin.FirstOrDefault(x => x.id.Equals(regVaksin.id));
            if (regVaksin != null)
            {
                newData.kode = regVaksin.kode;
                newData.jenis = regVaksin.jenis;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }

        public bool getRegVaksin(Reg_Vaksin regVaksin)
        {
            throw new NotImplementedException();
        }

        public Reg_Vaksin getDataRegVaksinById(int id)
        {
            TrackingVaksinEntities db = new TrackingVaksinEntities();
            Reg_Vaksin regVaksin = db.Reg_Vaksin.SingleOrDefault(x => x.id == id);
            return regVaksin;
        }

    }
}
