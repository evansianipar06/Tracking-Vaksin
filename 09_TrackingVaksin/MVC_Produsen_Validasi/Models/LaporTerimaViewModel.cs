using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Produsen_Validasi.Models
{
    public class LaporTerimaViewModel
    {
        public int idTer { get; set; }
        public Nullable<int> idLapor { get; set; }
        public string pengirim { get; set; }
        public string deskripsi { get; set; }
        public Nullable<int> idVak { get; set; }

        public string namaProdusen { get; set; }
        public string status { get; set; }
    }
}