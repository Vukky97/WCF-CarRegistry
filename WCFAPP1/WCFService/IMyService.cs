using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;

using WCFService.Faults;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {

        [OperationContract]
        [FaultContract(typeof(UsernameReservedFault))]
        bool Register(string username, string password);

        [OperationContract]
        [FaultContract(typeof(InvalidLoginFault))]
        bool Login(string username, string password);

        [OperationContract]
        [FaultContract(typeof(InvalidLoginFault))]
        bool IsAdmin(string adminName, string password);

        [OperationContract]
        [FaultContract(typeof(InvalidLogoutFault))]
        void Logout(string username);

        [OperationContract]
        [FaultContract(typeof(IncorrectDataFault))]
        void Add(string brand, string model, int productionYear, string engine, string transmission,
            string condition, int distanceTraveled, int price, string licensePlateNumber, string location, string phoneNumber);

        [OperationContract]
        [FaultContract(typeof(IncorrectDataFault))]
        void DeleteCar(int id);

        [OperationContract]
        [FaultContract(typeof(IncorrectDataFault))]
        void DeleteUser(int id);

        [OperationContract]
        [FaultContract(typeof(UnsuccesfullSearchFault))]
        Users GetUser(string username);

        [OperationContract]
        [FaultContract(typeof(UnsuccesfullSearchFault))]
        List<Users> GetAllUser();

        [OperationContract]
        [FaultContract(typeof(UnsuccesfullSearchFault))]
        CarRegistry GetCar(int id);

        [OperationContract]
        [FaultContract(typeof(UnsuccesfullSearchFault))]
        List<CarRegistry> GetCarList();

        [OperationContract]
        [FaultContract(typeof(IncorrectDataFault))]
        bool ChangePassword(string name, string oldPassword, string newPassword);

        [OperationContract]
        [FaultContract(typeof(IncorrectDataFault))]
        void Update(int id, string brand, string model, int productionYear, string engine, string transmission,
            string condition, int distanceTraveled, int price, string licensePlateNumber, string location, string phoneNumber);

        [OperationContract]
        [FaultContract(typeof(UnsuccesfullSearchFault))]
        CarRegistry FindCarByLicensePlateNumber(string licensePlateNumber);
    }
}
