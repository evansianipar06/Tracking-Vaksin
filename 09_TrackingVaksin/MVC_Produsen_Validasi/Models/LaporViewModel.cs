using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Produsen_Validasi.Models
{
    public class LaporViewModel
    {
        public int idLapor { get; set; }
        public string namaProdusen { get; set; }
        public string deskripsi { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> id { get; set; }
        public string kode { get; set; }
    }
}