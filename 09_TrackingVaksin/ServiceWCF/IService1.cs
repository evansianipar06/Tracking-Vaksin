using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Autentikasi
        [OperationContract]
        Login auth(Login data);

        [OperationContract]
        bool Login(string Username, string Password);

        [OperationContract]
        Login GetAkun(string Username);

        //Lapor Reg Vaksin
        [OperationContract]
        bool TambahLaporanVaksin(LaporValidasiVaksin data);

        [OperationContract]
        bool UpdateLaporanVaksin(LaporValidasiVaksin data);

        [OperationContract]
        bool DeleteLaporanVaksin(int idLapor);

        //Penggunaan Vaksin
        [OperationContract]
        bool TambahPenggunaanVaksin(PenggunaanVaksin data);

        [OperationContract]
        bool UpdatePenggunaanVaksin(PenggunaanVaksin data);

        [OperationContract]
        bool DeletePenggunaanVaksin(int idUsed);
    }
 
}
