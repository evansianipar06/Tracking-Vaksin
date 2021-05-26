using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Produsen_Validasi.Models
{
    public class PenggunaanVaksinViewModel
    {
        public int idUsed { get; set; }
        public string noRekamMedis { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> idRegVaksin { get; set; }
        public Nullable<int> idPend { get; set; }

        public string NIK { get; set; }
        public string kode { get; set; }

    }
}