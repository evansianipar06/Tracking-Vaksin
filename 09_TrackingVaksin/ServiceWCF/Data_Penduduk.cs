//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceWCF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data_Penduduk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Data_Penduduk()
        {
            this.CekValid = new HashSet<CekValid>();
            this.PenggunaanVaksin = new HashSet<PenggunaanVaksin>();
        }
    
        public int id { get; set; }
        public string NIK { get; set; }
        public string nama { get; set; }
        public string kelurahan { get; set; }
        public string kecamatan { get; set; }
        public string kota { get; set; }
        public int kode_pos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CekValid> CekValid { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PenggunaanVaksin> PenggunaanVaksin { get; set; }
    }
}
