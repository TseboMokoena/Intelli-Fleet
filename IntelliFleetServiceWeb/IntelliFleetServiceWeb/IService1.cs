using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;

namespace IntelliFleetServiceWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Client functions
        [OperationContract]
        [WebGet]
        bool Register(string Name, string Surname, string UName, string Email, string Password, string ConfirmPassword, int UType, string Active, string question, string ans);
        [OperationContract]


        [WebGet]
        bool Deregister(string UName, string Password);

        [OperationContract]
        [WebGet]
        bool CheckExisting(string name, string surname, string Username);

        [OperationContract]
        [WebGet]
        bool CheckExistingUsername(string name, string surname, string Username);

        [OperationContract]
        [WebGet]
        int Usertype(string username, string password);

        [OperationContract]
        [WebGet]
        string GetName(string username, string password);

        [OperationContract]
        [WebGet]
        string GetSurname(string username);

        [OperationContract]
        [WebGet]
        string GetNames(string username);

        [OperationContract]
        [WebGet]
        string GetEmail(string username);

        [OperationContract]
        [WebGet]
        void editInfo(string currentUSername, string name, string surname, string username, string email, string password);

        [OperationContract]
        [WebGet]
        void forgotPassword(String username, string password);

        [OperationContract]
        [WebGet]
        bool SercurityPur(string username, string question, string ans);

        [OperationContract]
        [WebGet]
        void Book(string User_Name, string Adress1, string Adress2, string Package_Type,
        double Package_Weight, double Package_Volume,
        DateTime Delivery_DateNTime, string Requirement,
        string Delivery_stat, string dateCollected, string deliveredDate);


        [OperationContract]
        [WebGet]
        void CancelBooking(int bookingID, string reason);

        [OperationContract]
        [WebGet]
        string ViewPendingOrderS(string Username);

        [OperationContract]
        [WebGet]
        string viewStatement(string username);

        [OperationContract]
        [WebGet]
        string ViewClientOrders(string Username);

        [OperationContract]
        [WebGet]
        string getbookingCollection(string username);

        [OperationContract]
        [WebGet]
        string getBookingDistination(string username);

        [OperationContract]
        [WebGet]
        string getBookingDuedate(string username);

        [OperationContract]
        [WebGet]
        double getbookingDistance(string username);

        [OperationContract]
        [WebGet]
        float getBookingPrice(string username);

        [OperationContract]
        [WebGet]
        int getbookingID(String username);

        [OperationContract]
        [WebGet]
         int getBookingPricingID(string username);
       
        [OperationContract]
        [WebGet]
         string getbookingEmail(string username);

        [OperationContract]
        [WebGet]
        string getRequirement(string username);
       
        //Driver functions
        [OperationContract]
        [WebGet]
        bool AddDriver(string Name, string Surname, string UName,
         string Email, string Password, string ConfirmPassword,
         int UType, string Active, string Licence_Number,
         string PDP_Number, string requirements,
         string startShift, string endShift,
         DateTime expiryDate, string dayOff);

        [OperationContract]
        [WebGet]
        List<String> GetDriverUsernames();

        [OperationContract]
        [WebGet]
        bool editDriver(string Name, string Surname,
            string UName, string Email,
             string Licence_Number, string PDP_Number,
            string requirements, string startShift,
            string endShift, string expiryDate,
            string dayOff);

        [OperationContract]
        [WebGet]
        bool removeDriver(string UName);

        [OperationContract]
        [WebGet]
        void RemoveDriver1(string Username);

        [OperationContract]
        [WebGet]
        string ViewDrivers();

        [OperationContract]
        [WebGet]
        string ViewOffDrivers();

        [OperationContract]
        [WebGet]
        string ViewAvailableDrivers();

        [OperationContract]
        [WebGet]
        string ViewAllDrivers();

        [OperationContract]
        [WebGet]
        string ViewWorkingDrivers();

        [OperationContract]
        [WebGet]
        List<string> RetrieveDriverDetails(string Username);

        //[OperationContract]
        //[WebGet]
        //void AssignBooking(string Username, DateTime BookingDateNTime);

        [OperationContract]
        [WebGet]
        void AssignDriver(string VehicleRegistration);

        [OperationContract]
        [WebGet]
        int getDriverBookingID(string username);

        [OperationContract]
        [WebGet]
        string getDriverCollectionAddres(string BookingID);

        [OperationContract]
        [WebGet]
        string getDriverDistinationAddres(int BookingID);

        //driver map functions
        [OperationContract]
        [WebGet]
        string GetDriversLat(string DriverUsername);

        [OperationContract]
        [WebGet]
        string GetDriversLng(string DriverUsername);

        [OperationContract]
        [WebGet]
        string getDrivername(string Username);

        [OperationContract]
        [WebGet]
        string getDriverSurname(string Username);

        [OperationContract]
        [WebGet]
        string getDriverVehicle(string Username);

        [OperationContract]
        [WebGet]
        int getDriverNumJobs(string Username);

        [OperationContract]
        [WebGet]
        void driverAvailability(string username);

        [OperationContract]
        [WebGet]
        List<int> getDriverJobs(string username);

        [OperationContract]
        [WebGet]
        string getDriverDueDate(int bookingID);

        [OperationContract]
        [WebGet]
        string getBookingDescription(int bookingID);

        [OperationContract]
        [WebGet]
        List<String> getMaintanceVehicles();

        [OperationContract]
        [WebGet]
        void updateVehicleDimentions();
        
        //vehicle functions   
        [OperationContract]
        [WebGet]
        void AddVehicle(string Veh_reg, string Type, double Veh_Volume,
            double weight, double kilometer, DateTime ExperingDate,
            string Available, string status);

        [OperationContract]
        [WebGet]
        bool RemoveVehicle(string Registration_Num);

        [OperationContract]
        [WebGet]
        void GetAssignedVehicle();

        [OperationContract]
        [WebGet]
        void UpdateVehicleAvailability(string Vehicle_Reg);

        [OperationContract]
        [WebGet]
        string ViewVehicles();

        [OperationContract]
        [WebGet]
        string viewMaintanceVehicles();

        [OperationContract]
        [WebGet]
        string viewReportedVehicles();

        [OperationContract]
        [WebGet]
        string viewDamagedVehicles();

        [OperationContract]
        [WebGet]
        string viewVehiclesExpiredPlate();

        [OperationContract]
        [WebGet]
        void UpdateVehicleActive(string Vehicle_Reg);

        //report functions
        [OperationContract]
        [WebGet]
        int getWeeklySales(DateTime DT);

        [OperationContract]
        [WebGet]
        List<object> getBarData(string year);
		
        [OperationContract]
        [WebGet]
		DataTable commonFuntionGetData(string strQuery);

        [OperationContract]
        [WebGet]
		int getInformation();

        [OperationContract]
        [WebGet]
		int getData();

        [OperationContract]
        [WebGet]
		int getData1();

        [OperationContract]
        [WebGet]
        int getServiceInformation(DateTime date);
		

        //manager functions
        [OperationContract]
        [WebGet]
        bool AddManager(string Name, string Surname, string UName,
          string Email, string Password, string ConfirmPassword,
          int UType, string Active);

        [OperationContract]
        [WebGet]
        string ViewOrders();

        [OperationContract]
        [WebGet]
        string ViewAllPendingOrders();

        [OperationContract]
        [WebGet]
        void Assign_Booking(int Booking_ID, int Driver_ID);

        [OperationContract]
        [WebGet]
        List<String> getDriverWaypoints(string username);

        //-------------------------------android------------------
        [OperationContract]
        [WebGet(UriTemplate = "/Login/{username}/{password}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Login(string username, string password);

        [OperationContract]
        [WebGet(UriTemplate = "/GetVehicleReg/{Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetVehicleReg(string Username);

        [OperationContract]
        [WebGet(UriTemplate = "/ViewPending/{Booking_Description}")]
          //BodyStyle = WebMessageBodyStyle.Wrapped,
          //RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ViewPending(string Booking_Description);

        [OperationContract]
        [WebGet(UriTemplate = "/UpdateVehicleCheckOut/{Username}/{Vehicle_Reg}",
          BodyStyle = WebMessageBodyStyle.Wrapped,
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        string UpdateVehicleCheckOut(string Username, string Vehicle_Reg);

        [OperationContract]
        [WebGet(UriTemplate = "/UpdateVehicleCheckIn/{Username}/{Vehicle_Reg}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        string UpdateVehicleCheckIn(string Username, string Vehicle_Reg);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string UpdateCollection(string Booking_Description);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string UpdateDelivery(string Booking_Description);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string UpdateLocation(string Username, double Lat, double Long);

   
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        string UpdateKilometers(string Vehicle_Reg, double Kilometers);

        [OperationContract]
        [WebGet(UriTemplate = "/GetBookingDesciptions/{Vehicle_Reg}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        List<String> GetBookingDesciptions(string Vehicle_Reg);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCollectionAddresses/{Vehicle_Reg}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        List<String> GetCollectionAddresses(string Vehicle_Reg);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDeliveryAddresses/{Vehicle_Reg}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        List<String> GetDeliveryAddresses(string Vehicle_Reg);

        [OperationContract]
        [WebGet(UriTemplate = "/ReportProblem/{Vehicle_Reg}/{Message}",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json)]
        string ReportProblem(string Vehicle_Reg, string Message);

        

        //------------------------no longer needed-----------

        //Client
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Registration(string Name, string Surname, string UName, string Email, string Password,
            string ConfirmPassword, int UType, string Active, string question, string ans);

        [OperationContract]
        [WebGet(UriTemplate = "/CheckExistinG/{name}/{surname}/{Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CheckExistinG(string name, string surname, string Username);

        [OperationContract]
        [WebGet(UriTemplate = "/CheckExistingUName/{name}/{surname}/{Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CheckExistingUName(string name, string surname, string Username);

      
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Booking(string User_Name, string Adress1, string Adress2,
            string Package_Type, double Package_Weight,
            double Package_Length, double Package_Breath,
            double Package_Height, int Item_Quantity,
            DateTime Delivery_DateNTime, string Requirement,
            string Delivery_stat, string dateCollected,
            string deliveredDate);

        [OperationContract]
        [WebGet(UriTemplate = "/ViewClientOrderss/{username}")]
        string ViewClientOrderss(string Username);

        [OperationContract]
        [WebGet(UriTemplate = "/ViewStatement/{username}")]
        string ViewStatements(string username);


        //Driver functions
       

        [OperationContract]
        [WebGet(UriTemplate = "/GetBookingID/{Driver_Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int GetBooking_ID(string Driver_Username);

       
        [OperationContract]
        [WebGet(UriTemplate = "/GetOriginAddress/{Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetOriginAddress(string Username);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDestinationAddress/{Username}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetDestinationAddress(string Username);

  



        //vehicle
      

        //util
        [OperationContract]
        [WebGet]
        string GetDataUsingMethod(string username, string username2);

        [OperationContract]
        [WebGet(UriTemplate = "/GetString/{param}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetString(string param);


    }
    //http://localhost:3032/Service1.svc/GetString/Tsebo
    // http://localhost:3032/Service1.svc/GetInteger/1
    //http://localhost:3032/Service1.svc/GetDataUsingMethod?username=Admin&username2=tststs
    //http://localhost:3032/Service1.svc/GetSurname?username=Admin
}
