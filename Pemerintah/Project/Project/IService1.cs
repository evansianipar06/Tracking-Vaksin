using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project
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

        //Pemerintah
        [OperationContract]
        List<Data_Penduduk> datapenduduk();

       [OperationContract]
        bool tambahPenduduk(Data_Penduduk datapenduduk);

        [OperationContract]
        bool getPenduduk(Data_Penduduk data_Penduduk);

        [OperationContract]
        bool deletePenduduk(int id);

        [OperationContract]
        bool editPenduduk(Data_Penduduk data_Penduduk);

        [OperationContract]
        Data_Penduduk GetData_PendudukById(int id);

        //Reg Vaksin
        [OperationContract]
        List<Reg_Vaksin> dataRegVaksin();

        [OperationContract]
        bool tambahRegVaksin(Reg_Vaksin regVaksin);

        [OperationContract]
        bool hapusRegVaksin(int id);

        [OperationContract]
        bool editRegVaksin(Reg_Vaksin regVaksin);

        [OperationContract]
        bool getRegVaksin(Reg_Vaksin regVaksin);

        [OperationContract]
        Reg_Vaksin getDataRegVaksinById(int id);
    }

}
