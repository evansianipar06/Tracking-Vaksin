using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Produsen_Validasi.Models
{
    public class CekRegPasienViewModel
    {
        public int id { get; set; }
        public Nullable<int> idRegVaksin { get; set; }
        public Nullable<int> idPend { get; set; }
        public Nullable<int> idVak { get; set; }

        public string NIK { get; set; }
        public string nama { get; set; }
        public string kelurahan { get; set; }
        public string kecamatan { get; set; }
        public string kota { get; set; }
        public string kode { get; set; }
        public string status { get; set; }

       
    }
}