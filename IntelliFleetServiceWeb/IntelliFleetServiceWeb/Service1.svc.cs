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
using MySql.Data.MySqlClient;




namespace IntelliFleetServiceWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private MySqlConnection connection = new MySqlConnection();
        private MySqlConnection connection2 = new MySqlConnection();
        private MySqlConnection connection3 = new MySqlConnection();
        private String ConString1 = "Data Source=OBEST-PC;Initial Catalog=TestDatabase;Integrated Security=True;TrustServerCertificate=True";
        //    private String ConString = @"Data Source=OBEST-PC\SQLEXPRESS;Initial Catalog=IntelliFleetDB;Integrated Security=True;MultipleActiveResultSets=True ";
        private String ConString = "Server=localhost;persistsecurityinfo=True;Database=intellifleetdb;Uid=root;"
            + "Pwd=1234;Convert Zero Datetime=True;Allow Zero Datetime=True;";
        // private String ConString = @"Data Source=OBEST-PC\SQLEXPRESS;Initial Catalog=IntelliFleetDB;Integrated Security=True;MultipleActiveResultSets=True "; 
        private bool match = false;
      //  private int ID;


        //Client functions
        public bool Register(string Name, string Surname, string UName, string Email, string Password,
            string ConfirmPassword, int UType, string Active, string question, string ans)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            bool success = false;


            if (Password == ConfirmPassword)
            {
                string hashPassword = HashPassword(Password);
                MySqlCommand command = new MySqlCommand("INSERT INTO USERS(NAME , SURNAME , USERNAME ,  EMAIL ,USER_PASSWORD , USER_TYPE,ACTIVE_USER,S_QUESTION,S_ANSWER ) VALUES "
                   + "('" + Name + "','" + Surname + "','" + UName + "' , '" + Email + "','" + hashPassword + "','" + UType + "','" + Active + "','" + question + "','" + ans + "')", connection);

                command.ExecuteNonQuery();

                success = true;
            }
            else if (Password != ConfirmPassword)
            {
                success = false;
            }

            connection.Close();
            return success;
        }

        public bool Deregister(string UName, string Password)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * from USERS ", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string Name = "";
            string Surname = "";
            string UserName = "";
            string UPassword = "";
            bool Deregistetred = false;


            while (reader.Read())
            {
                Name = reader.GetString(1);
                Surname = reader.GetString(2);
                UserName = reader.GetString(3);
                UPassword = reader.GetString(5);

                if (UserName == UName)
                {
                    if (HashPassword(Password) == UPassword)
                    {
                        match = true;
                    }
                }

                else if (HashPassword(Password) != UPassword)
                {
                    Deregistetred = false;
                }

            }

            connection.Close();

            if (match == true)
            {
                connection.Open();
                MySqlCommand command2 = new MySqlCommand("UPDATE USERS SET ACTIVE_USER = 'false' WHERE USERNAME ='" + UserName + "'", connection);
                command2.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                MySqlCommand command3 = new MySqlCommand("INSERT INTO INACTIVE_USERS (NAME , SURNAME, USERNAME) VALUES ('" + Name + "','" + Surname + "', '" + UserName + "')", connection);
                command3.ExecuteNonQuery();
                Deregistetred = true;
            }

            connection.Close();
            return Deregistetred;
        }

        public bool CheckExisting(string name, string surname, string Username)
        {
            bool exist = false;
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from INACTIVE_USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string Name = "";
            string UserSuname = "";
            string UserName = "";

            while (reader.Read())
            {

                Name = reader.GetString(1);
                UserSuname = reader.GetString(2);
                UserName = reader.GetString(3);

                if (name == Name)
                {
                    if (surname == UserSuname)
                    {
                        if (Username == UserName)
                        {
                            exist = true;
                        }
                    }
                }

            }

            connection.Close();

            return exist;
        }

        public bool CheckExistingUsername(string name, string surname, string Username)
        {
            bool exist = false;
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UserName = "";

            while (reader.Read())
            {
                UserName = reader.GetString(3);
                if (Username == UserName)
                {
                    exist = true;
                }
            }

            connection.Close();

            return exist;
        }

        public int Usertype(string username, string password)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();

           
            string UName = "";
            string UPassword = "";
            int UserType = 0;
            int state = 0;
            string active = "";


            while (reader.Read())
            {

                UName = reader.GetString(3);
                UPassword = reader.GetString(5);
                UserType = reader.GetInt32(6);
                active = reader.GetString(7);

                if (UName == username)
                {

                    if (UPassword == HashPassword(password))
                    {

                        if (UserType == 1) //user is a client
                        {

                            state = 1;
                            if (active == "false")
                            {
                                state = -1;
                            }

                        }

                        else if (UserType == 2) //user is a driver
                        {
                            state = 2;

                            if (active == "false")
                            {
                                state = -1;
                            }

                        }

                        else if (UserType == 3) //user is a manager
                        {
                            state = 3;

                            if (active == "false")
                            {
                                state = -1;
                            }

                        }
                    }
                }


            }

            connection.Close();
            return state;
        }

        public string GetName(string username, String Password)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UName = "";
            string UPassword = "";
            string Name = "";

            while (reader.Read())
            {

                UName = reader.GetString(3);
                UPassword = reader.GetString(5);


                if (UName == username)
                {


                    Name = UName;

                }
            }
            connection.Close();
            return Name;

        }

        public string GetSurname(string username)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UName = "";
            //string UPassword = "";
            string Surname = "";

            while (reader.Read())
            {

                UName = reader.GetString(3);
                //UPassword = reader.GetString(5);


                if (UName == username)
                {

                    //if (UPassword == HashPassword(password))
                    //{
                    Surname = reader.GetString(2);
                    //}
                }
            }
            connection.Close();
            return Surname;

        }

        public string GetNames(string username)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UName = "";
            //string UPassword = "";
            string Surname = "";

            while (reader.Read())
            {

                UName = reader.GetString(3);
                //UPassword = reader.GetString(5);


                if (UName == username)
                {

                    //if (UPassword == HashPassword(password))
                    //{
                    Surname = reader.GetString(1);
                    //}
                }
            }
            connection.Close();
            return Surname;

        }

        public string GetEmail(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UName = "";

            string Email = "";

            while (reader.Read())
            {

                UName = reader.GetString(3);
                if (UName == username)
                {


                    Email = reader.GetString(4);

                }
            }
            connection.Close();
            return Email;

        }

        public void editInfo(string currentUSername, string name, string surname,
            string username, string email, string password)
        {

            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command1 = new MySqlCommand("UPDATE USERS SET USERNAME = '" + username + "', NAME ='" + name + "',SURNAME ='" + surname + "',EMAIL='" + email + "',USER_PASSWORD='" + HashPassword(password) + "'  WHERE USERNAME ='" + currentUSername + "'", connection);
            command1.ExecuteNonQuery();

            connection.Close();


        }

        public void forgotPassword(String username, string password)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {

                if (username == reader.GetString(3))
                {

                    MySqlCommand command1 = new MySqlCommand("UPDATE USERS SET USER_PASSWORD = '" + HashPassword(password) + "' WHERE USERNAME ='" + username + "'", connection);
                    command1.ExecuteNonQuery();

                }


            }

            connection.Close();


        }

        public bool SercurityPur(string username, string question, string ans)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS WHERE USERNAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            bool confirm = false;

            while (reader.Read())
            {


                if (question == reader.GetString(8))
                {

                    if (ans == reader.GetString(9))
                    {
                        confirm = true;

                    }
                }


            }

            connection.Close();
            return confirm;


        }

        /**/
        public void Book(string User_Name, string Adress1, string Adress2, string Package_Type,
        double Package_Weight, double Package_Volume,
        DateTime Delivery_DateNTime, string Requirement,
        string Delivery_stat, string dateCollected, string deliveredDate)
        {
            double price = 0;
            string vehicle_Reg;
            DateTime Booking_Date = DateTime.Now;
            string Booking_Description = "";


            int distance;
            Random random;
            random = new Random();
          //  distance = random.NextDouble() * (2 - 1) + 1;  
            distance = 1; 

            //  vehicle_Reg = GetAssignedVehicle(tot, volume);
            vehicle_Reg = "NONE";

            Booking_Description = User_Name + "-" + Package_Type;


            if (Package_Weight <= 5000)
            {
                if (Package_Volume <= 200000)
                {
                    //price = (price + 2000);
                    price = distance * 50; 
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }
                    //5ton
                     
                }

            }
            else if (Package_Weight > 5000 && Package_Weight <= 10000)
            {
                if (Package_Volume > 200000 && Package_Volume <= 450000)
                {
                    //price = (price + 3000);
                    price = distance * 60; 
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }

                }//10ton
              //  price += price + 300;
            }
            else if (Package_Weight > 10000 && Package_Weight <= 20000)
            {
                if (Package_Volume > 450000 && Package_Volume <= 900000)
                {
                  //  price = (price + 4000);
                    price = distance * 70; 
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }
                    //20ton
                //    price += price + 400;

                }
            }

                connection.ConnectionString = ConString;
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO BOOKINGS (USER_NAME, COLLECTION_ADR , DELIVERY_ADR ,TYPE," +
                                    " WEIGHT_KG,VOLUME," +
                                    " BOOKING_DATE,DUE_DATE,REQUIREMENT,STATUS,COLLECTION_DATE,DELIVERED_DATE, VEHICLE_REG, BOOKING_DESCRIPTION) VALUES "
                                    + "('" + User_Name + "','" + Adress1 + "','" + Adress2 + "' , '" + Package_Type
                                    + "','" + Package_Weight + "','" + Package_Volume
                                    + "','" + Booking_Date + "','" + Delivery_DateNTime
                                    + "','" + Requirement + "','" + Delivery_stat + "','" + dateCollected + "','" + deliveredDate + "','" + vehicle_Reg + "', '" + Booking_Description + "')", connection);


                command.ExecuteNonQuery();
                connection.Close();

          

                connection.ConnectionString = ConString;
                connection.Open();

                MySqlCommand command2 = new MySqlCommand("INSERT INTO PRICING(USER_NAME , PACKAGE_TYPE , REQUIREMENT, TOTAL_WEIGHT_KG , VOLUME , DISTANCE , BOOKING_DATE , DUE_DATE , ITEM_PRICE_RANDS) VALUES "
                   + "('" + User_Name + "','" + Package_Type + "','" + Requirement + "','" + Package_Weight + "','" + Package_Volume + "','" + distance + "','" + Booking_Date + "','" + Delivery_DateNTime + "','" + price + "')", connection);

                command2.ExecuteNonQuery();

                connection.Close();

        }

        public void CancelBooking(int bookingID, string reason)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO CANCELATIONS(BOOKING_ID, REASON) VALUES "
                   + "('" + bookingID + "','" + reason + "')", connection);
            command = new MySqlCommand("DELETE * FROM BOOKINGS WHERE BOOKING_ID = " + bookingID + "", connection);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public string ViewPendingOrderS(string Username)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select COLLECTION_ADR,DELIVERY_ADR,TYPE, WEIGHT_KG,VOLUME ,BOOKING_DATE,DUE_DATE,REQUIREMENT, STATUS,COLLECTION_DATE,DELIVERED_DATE from BOOKINGS WHERE USER_NAME = '" + Username + "' AND STATUS = 'In Progress'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Collection Address</th>");
            html.Append("<th>Delivery Address</th>");
            html.Append("<th>Package Description</th>");
            html.Append("<th>Item Weight(kg)</th>");
            html.Append("<th>Item volume(m^3)</th>");
            html.Append("<th>Booking Date </th>");
            html.Append("<th>Due Date</th>");
            html.Append("<th>Requirement</th>");
            html.Append("<th>Package Status</th>");
            html.Append("<th>Collection Date </th>");
            html.Append("<th>Delivery Date </th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        /**/
        public string viewStatement(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            DataSet dataSet = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select PRICING_ID,USER_NAME,PACKAGE_TYPE, REQUIREMENT, TOTAL_WEIGHT_KG,VOLUME, DISTANCE, BOOKING_DATE, DUE_DATE, ITEM_PRICE_RANDS from PRICING WHERE USER_NAME = '" + username + "'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Reciept Number</th>");
            html.Append("<th>Client Name</th>");
            html.Append("<th>Package Type</th>");
            html.Append("<th>Requiment</th>");
            html.Append("<th>Package Weight(kg)</th>");
            html.Append("<th>Package Volume(m^3)</th>");
            html.Append("<th>Distance(km) </th>");
            html.Append("<th>Booking Date</th>");
            html.Append("<th>Due Date</th>");
            html.Append("<th>Total Price(R)</th>");
            
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");
            connection.Close();
            return html.ToString();



        }

        public string ViewClientOrders(string Username)
        {
            //we need to find a way to use the user's id for this
            //session  variables and cookies
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select COLLECTION_ADR, DELIVERY_ADR, TYPE, WEIGHT_KG, VOLUME, BOOKING_DATE, DUE_DATE, REQUIREMENT, STATUS, COLLECTION_DATE, DELIVERED_DATE from BOOKINGS WHERE USER_NAME = '" + Username + "'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Collection Address</th>");
            html.Append("<th>Delivery Address</th>");
            html.Append("<th>Package Description</th>");
            html.Append("<th>Item Weight(kg)</th>");
            html.Append("<th>Item Volume(m^3)</th>");
            html.Append("<th>Booking Date</th>");
            html.Append("<th>Due Date</th>");
            html.Append("<th>Requirement</th>");
            html.Append("<th>Package Status</th>");
            html.Append("<th>Collection Date</th>");
            html.Append("<th>Delivery Date</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");
            connection.Close();
            return html.ToString();


        }

        /**/
        public string getbookingCollection(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string collecAdress = "";

            while (reader.Read())
            {

                collecAdress = reader.GetString(2);

            }

            connection.Close();
            return collecAdress;

        }

        /**/
        public string getBookingDistination(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string DisAdress = "";

            while (reader.Read())
            {

                DisAdress = reader.GetString(3);

            }

            connection.Close();
            return DisAdress;
        }

        /**/
        public string getBookingDuedate(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string Date = "";

            while (reader.Read())
            {

                Date = reader.GetString(8);

            }

            connection.Close();
            return Date;
        }

        /**/
        public double getbookingDistance(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from PRICING WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            double distance = 0;

            while (reader.Read())
            {

                distance = reader.GetDouble(6);

            }

            connection.Close();
            return distance;
        }

        /**/
        public float getBookingPrice(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from PRICING WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            float price = 0;

            while (reader.Read())
            {
                price = reader.GetFloat(9);
            }

            connection.Close();
            return price;

        }

        /**/
        public int getbookingID(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            int id = 0;

            while (reader.Read())
            {

                id = reader.GetInt32(0);

            }

            connection.Close();
            return id;

        }

        /**/
        public int getBookingPricingID(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from PRICING WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            int id = 0;

            while (reader.Read())
            {

                id = reader.GetInt32(0);

            }

            connection.Close();
            return id;

        }

        public string getbookingEmail(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS WHERE USERNAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string email = "";

            while (reader.Read())
            {

                email = reader.GetString(4);

            }

            connection.Close();
            return email;
        }

        public string getRequirement(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from PRICING WHERE USER_NAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string req ="";

            while (reader.Read())
            {

                req = reader.GetString(3);

            }

            connection.Close();
            return req;
        }
       
        //Driver functions
        public bool AddDriver(string Name, string Surname, string UName, string Email,
            string Password, string ConfirmPassword, int UType, string Active,
            string Licence_Number, string PDP_Number, string requirements,
            string startShift, string endShift, DateTime expiryDate, string dayOff)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            bool success = false;
            int booking_ID = 0;
            String Available = "true";
            requirements = "true";
            dayOff = "false";
            UType = 2;

            if (Password == ConfirmPassword)
            {
                string hashPassword = HashPassword(Password);
                MySqlCommand command = new MySqlCommand("INSERT INTO USERS(NAME , SURNAME , USERNAME ,  EMAIL ,USER_PASSWORD , USER_TYPE , ACTIVE_USER) VALUES "
                   + "('" + Name + "','" + Surname + "','" + UName + "' , '" + Email + "','" + hashPassword + "','" + UType + "','" + Active + "')", connection);

                command.ExecuteNonQuery();

                MySqlCommand command2 = new MySqlCommand("INSERT INTO DRIVERS (DRIVER_USERNAME,LICENCE_NUMBER, PDP_LICENCE_NUMBER, BOOKING_AVAILABILITY, REQUIREMENTS, START_SHIFT, END_SHIFT, LICENSE_EXPIRY_DATE, DAY_OFF,LATITUDE_COORDINATES,LONGITUDE_COORDINATES,VEHICLE_ASSIGNED) VALUES "
                 + "('" + UName + "' ,'" + Licence_Number + "', '" + PDP_Number + "','" + Available + "','" + requirements + "','" + startShift + "','" + endShift + "','" + expiryDate + "','" + dayOff + "','" + -26.182181 + "','" + 27.998111 + "','NONE')", connection);

                command2.ExecuteNonQuery();


                success = true;
            }
            else if (Password != ConfirmPassword)
            {
                success = false;
            }


            connection.Close();
            return success;
        }

        public List<String> GetDriverUsernames()
        {


            List<string> Driver = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from DRIVERS", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                Driver.Add(reader2.GetString(1));

            }

            connection.Close();

            return Driver;

        }

        /**/
        public bool editDriver(string Name, string Surname, string UName, string Email,
             string Licence_Number, string PDP_Number, string requirements, string startShift,
            string endShift, string expiryDate, string dayOff)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            bool success = false;
            

            MySqlCommand command2 = new MySqlCommand("UPDATE DRIVERS SET DRIVER_USERNAME = '"+UName+"',"
            + "LICENCE_NUMBER = '" + Licence_Number + "', PDP_LICENCE_NUMBER = '" + PDP_Number + "', "
            + "START_SHIFT ='" + startShift + "', END_SHIFT ='" + endShift + "', "
            + "LICENSE_EXPIRY_DATE ='" + expiryDate + "', REQUIREMENTS='"+requirements+"', DAY_OFF ='" + dayOff + "' WHERE DRIVER_USERNAME = '" + UName + "'", connection);
        
            command2.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            MySqlCommand command = new MySqlCommand("UPDATE USERS SET USERNAME = '" + UName + "' , NAME = '" + Name + "', "
            + "SURNAME = '" + Surname + "', EMAIL = '" + Email + "' WHERE USERNAME ='" + UName + "'", connection);
           
            return success;
        }

        public bool removeDriver(string UName)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * from USERS ", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string Name = "";
            string Surname = "";
            string UserName = "";

            bool Deregistetred = false;


            while (reader.Read())
            {

                UserName = reader.GetString(3);


                if (UserName == UName)
                {
                    Name = reader.GetString(1);
                    Surname = reader.GetString(2);
                    match = true;

                }

            }

            connection.Close();

            if (match == true)
            {
                connection.Open();
                MySqlCommand command2 = new MySqlCommand("UPDATE USERS SET ACTIVE_USER = 'false' WHERE USERNAME ='" + UserName + "'", connection);
                command2.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                MySqlCommand command4 = new MySqlCommand("DELETE FROM DRIVERS WHERE DRIVER_USERNAME ='" + UserName + "'", connection);
                command4.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                MySqlCommand command5 = new MySqlCommand("DELETE FROM USERS WHERE USERNAME ='" + UserName + "'", connection);
                command5.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                MySqlCommand command3 = new MySqlCommand("INSERT INTO INACTIVE_USERS (NAME , SURNAME, USERNAME) VALUES ('" + Name + "','" + Surname + "', '" + UserName + "')", connection);
                command3.ExecuteNonQuery();

                Deregistetred = true;


            }

            connection.Close();
            return Deregistetred;
        }

        public void RemoveDriver1(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE * FROM DRIVERS WHERE NAME = '" + Username + "'", connection);

            command.ExecuteNonQuery();
            connection.Close();


        }

        public string ViewDrivers()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select USER_ID ,NAME,	SURNAME,	USERNAME,	EMAIL from USERS WHERE USER_TYPE = '" + 2 + "'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>User ID</th>");
            html.Append("<th>Name</th>");
            html.Append("<th>Surname</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Email </th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        public string ViewAvailableDrivers()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from DRIVERS WHERE BOOKING_AVAILABILITY = 'true'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Driver ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Licence Number</th>");
            html.Append("<th>PDP Licence Number</th>");
            html.Append("<th>Booking Availability</th>");

            html.Append("<th>Requiments</th>");
            html.Append("<th>Shit Start</th>");
            html.Append("<th>Shift End</th>");
            html.Append("<th>Licence Expiry Date</th>");
            html.Append("<th>Day Off</th>");
            html.Append("<th>Last Lattitude</th>");
            html.Append("<th>Last Longitude</th>");
            html.Append("<th>Assigned Vehicle</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        public string ViewOffDrivers()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from DRIVERS WHERE DAY_OFF = 'true'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Driver ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Licence Number</th>");
            html.Append("<th>PDP Licence Number</th>");
            html.Append("<th>Booking Availability</th>");

            html.Append("<th>Requiments</th>");
            html.Append("<th>Shit Start</th>");
            html.Append("<th>Shift End</th>");
            html.Append("<th>Licence Expiry Date</th>");
            html.Append("<th>Day Off</th>");
            html.Append("<th>Last Lattitude</th>");
            html.Append("<th>Last Longitude</th>");
            html.Append("<th>Assigned Vehicle</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();
        }

        public string ViewAllDrivers()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            DataSet dataSet = new DataSet();
            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter("SELECT * FROM DRIVERS ", connection);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Driver ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Licence Number</th>");
            html.Append("<th>PDP Licence Number</th>");
            html.Append("<th>Booking Availability</th>");

            html.Append("<th>Requiments</th>");
            html.Append("<th>Shit Start</th>");
            html.Append("<th>Shift End</th>");
            html.Append("<th>Licence Expiry Date</th>");
            html.Append("<th>Day Off</th>");
            html.Append("<th>Last Lattitude</th>");
            html.Append("<th>Last Longitude</th>");
            html.Append("<th>Assigned Vehicle </th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();
        }

        public string ViewWorkingDrivers()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            DataSet dataSet = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM DRIVERS WHERE BOOKING_AVILABILITY = 'false'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Driver ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Licence Number</th>");
            html.Append("<th>Booking Availability</th>");
            html.Append("<th>Assigned Booking </th>");
            html.Append("<th>Requiments</th>");
            html.Append("<th>Shit Start</th>");
            html.Append("<th>Shift End</th>");
            html.Append("<th>Licence Expiry Date</th>");
            html.Append("<th>Day Off</th>");
            html.Append("<th>Last Lattitude</th>");
            html.Append("<th>Last Longitude</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        public List<string> RetrieveDriverDetails(string Username)
        {


            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS  WHERE USERNAME = '" + Username + "'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<string> DriverDetails = new List<string>();

            while (reader.Read())
            {
                
                string UName = reader.GetString(3);

                if (UName == Username)
                {

                    DriverDetails.Add(reader.GetString(1)); //name
                    DriverDetails.Add(reader.GetString(2)) ; //surname
                    DriverDetails.Add(reader.GetString(4)); //email
                }
            }
            connection.Close();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                DriverDetails.Add(reader2.GetString(1)); //username
                DriverDetails.Add(reader2.GetString(2)); //licence
                DriverDetails.Add(reader2.GetString(3)); //pdp
                DriverDetails.Add(reader2.GetString(5)); //req
                DriverDetails.Add( reader2.GetString(6)); //start
                DriverDetails.Add(reader2.GetString(7)); //end
                DriverDetails.Add( reader2.GetString(8)); //exp date
                 DriverDetails.Add( reader2.GetString(9)); //day off


            }

            connection.Close();

            return DriverDetails;

        }

        //public void AssignBooking(string Username, DateTime BookingDateNTime)
        //{
        //    int BookingID = 0;
        //    int DriverID = 0;

        //    connection.ConnectionString = ConString;
        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand("SELECT * FROM BOOKINGS WHERE USER_NAME='" + Username + "' AND BOOKING_DATE='" + BookingDateNTime + "'", connection);
        //    MySqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        BookingID = reader.GetInt32(0);

        //    }
        //    connection.Close();

        //    connection.ConnectionString = ConString;
        //    connection.Open();
        //    MySqlCommand command4 = new MySqlCommand("SELECT TOP 1 * FROM DRIVERS WHERE BOOKING_AVAILABILITY='true'", connection);
        //    MySqlDataReader reader4 = command4.ExecuteReader();

        //    while (reader4.Read())
        //    {
        //        DriverID = reader4.GetInt32(0);

        //    }
        //    connection.Close();

        //    connection.ConnectionString = ConString;
        //    connection.Open();
        //    MySqlCommand command2 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' ,BOOKING_ID ='" + BookingID + "' WHERE DRIVER_ID ='" + DriverID + "'", connection);
        //    command2.ExecuteNonQuery();

        //    connection.Close();


        //}

        public void AssignDriver(string VehicleRegistration)
        {

            int DriverID = 0;


            //connection.ConnectionString = ConString;
            //connection.Open();
            MySqlCommand command4 = new MySqlCommand("SELECT TOP 1 * FROM DRIVERS WHERE BOOKING_AVAILABILITY='True'", connection);
            MySqlDataReader reader4 = command4.ExecuteReader();

            while (reader4.Read())
            {
                DriverID = reader4.GetInt32(0);

            }
            //connection.Close();

            //connection.ConnectionString = ConString;
            //connection.Open();
            MySqlCommand command2 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'False', VEHICLE_ASSIGNED ='" + VehicleRegistration + "'  WHERE DRIVER_ID ='" + DriverID + "'", connection);
            command2.ExecuteNonQuery();

            //connection.Close();


        }

   /*     public string getDriverCollectionAddres(string username)
             {
            
                 string collectionAddress = ""; 
           

                 connection.ConnectionString = ConString;
                 connection.Open();
           
                  int DriverBID = 0;

          
                 MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME ='" + username + "'", connection);
                 MySqlDataReader reader = command.ExecuteReader();
           
           
                 while (reader.Read())
                 {
                         
                     DriverBID = reader.GetInt32(5);

                 }
                 connection.Close(); 

                 connection.ConnectionString = ConString;
                 connection.Open();
                 MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + DriverBID + "'  ", connection);
                 MySqlDataReader reader2 = command.ExecuteReader();
          

                 while (reader2.Read())
                 {

                     collectionAddress = reader.GetString(2);

                 }

                 connection.Close();

                 return collectionAddress;
             }
        
         public string getDriverDistinationAddres(string username)
             {
                 int DriverBID = 0;
                 string DestinationAdress = "";

                 connection.ConnectionString = ConString;
                 connection.Open();
   
                 MySqlCommand command = new MySqlCommand("select * from DRIVERS  WHERE DRIVER_USERNAME ='" + username + "'  ", connection);
                 MySqlDataReader reader = command.ExecuteReader();


                 while (reader.Read())
                 {

                     DriverBID = reader.GetInt32(5);

                 }

                 connection.Close();

                 connection.ConnectionString = ConString;
                 connection.Open();
                 MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + DriverBID + "'  ", connection);
                 MySqlDataReader reader2 = command2.ExecuteReader();
           
                 while (reader2.Read())
                 {

                     DestinationAdress = reader2.GetString(3);

                 }

                 connection.Close();

                 return DestinationAdress;
             }
     */

        public int getDriverBookingID(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from DRIVERS  WHERE DRIVER_USERNAME ='" + username + "'  ", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

            int DriverBID = 0;
            while (reader2.Read())
            {

                DriverBID = reader2.GetInt32(5);

            }

            connection.Close();

            return DriverBID;

        }

        /**/
        public string getDriverCollectionAddres(string BookingID)
        {
         //   int driverbID = 0;
        //    driverbID = getDriverBookingID(username);
            connection.ConnectionString = ConString;
            connection.Open();

            string collectionAddress = "";
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + BookingID + "'  ", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                collectionAddress = reader2.GetString(2);

            }

            connection.Close();

            return collectionAddress;
        }

        /**/
        public string getDriverDistinationAddres(int BookingID)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            string dest = "";
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + BookingID + "'  ", connection);

            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                dest = reader2.GetString(3);
            }

            connection.Close();

            return dest;
        }
       
        /**/
        public string GetDriversLat(string DriverUsername)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + DriverUsername + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string Lat = "";


            while (reader.Read())
            {
                if (DriverUsername == reader.GetString(1))
                {
                    Lat = reader.GetString(10);
                }
            }


            return Lat;

        }

        /**/
        public string GetDriversLng(string DriverUsername)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + DriverUsername + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string Lng = "";


            while (reader.Read())
            {
                if (DriverUsername == reader.GetString(1))
                {

                    Lng = reader.GetString(11);
                }
            }


            return Lng;
        }

        public string getDrivername(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS WHERE USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string name = "";

            while (reader.Read())
            {

                name = reader.GetString(1);

            }
            connection.Close();
            return name;
        }

        public string getDriverSurname(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS WHERE USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string name = "";

            while (reader.Read())
            {

                name = reader.GetString(2);

            }
            connection.Close();
            return name;
        }

        public string getDriverVehicle(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string vehicle = "";

            while (reader.Read())
            {

                vehicle = reader.GetString(12);

            }
            connection.Close();
            return vehicle;
        }

        public int getDriverNumJobs(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string vehicle = "";

            while (reader.Read())
            {

                vehicle = reader.GetString(12);

            }
            connection.Close();

            connection.Open();
            MySqlCommand command1 = new MySqlCommand("select * from BOOKINGS ", connection);
            MySqlDataReader reader2 = command1.ExecuteReader();
            int num = 0;

            while (reader2.Read())
            {

                if (vehicle == reader2.GetString(13))
                {
                    num = num + 1;
                }

            }
            connection.Close();
            return num;
        }

        public void driverAvailability(string username)
        {
            string dayOff = "";
            DateTime startTime;
            DateTime endTime;
            string requirements;
            DateTime expiryDate;
            DateTime currentTime = DateTime.Now;

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command5 = new MySqlCommand("SELECT * from DRIVERS", connection);
            MySqlDataReader reader = command5.ExecuteReader();

            while (reader.Read())
            {
                requirements = reader.GetString(6);
                startTime = reader.GetDateTime(7);
                endTime = reader.GetDateTime(8);
                expiryDate = reader.GetDateTime(9);
                dayOff = reader.GetString(10);

                if (requirements == "false")
                {
                    //connection.ConnectionString = ConString;
                    //connection.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' WHERE USERNAME ='" + username + "'", connection);
                    command.ExecuteNonQuery();
                    //connection.Close();

                    if (expiryDate > currentTime)
                    {
                        //    connection.ConnectionString = ConString;
                        //   connection.Open();
                        MySqlCommand command2 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' WHERE USERNAME ='" + username + "'", connection);
                        command2.ExecuteNonQuery();
                        //   connection.Close();

                        if (dayOff == "true")
                        {
                            //    connection.ConnectionString = ConString;
                            //    connection.Open();

                            MySqlCommand command3 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' WHERE USERNAME ='" + username + "'", connection);
                            command3.ExecuteNonQuery();
                            //  connection.Close();

                            if (startTime < currentTime && endTime < currentTime)
                            {
                                //      connection.ConnectionString = ConString;
                                //       connection.Open();

                                MySqlCommand command4 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' WHERE USERNAME ='" + username + "'", connection);
                                command4.ExecuteNonQuery();
                                //     connection.Close();
                            }
                        }
                    }
                }
            }
            connection.Close();
        }

        public List<int> getDriverJobs(string username)
        {
            int NumberOFJobs = getDriverNumJobs(username);
            string Vehicle = getDriverVehicle(username);
            connection.ConnectionString = ConString;
            connection.Open();

            List<int> num = new List<int>();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE VEHICLE_REG = '" + Vehicle + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                num.Add(reader.GetInt32(0));

            }
            connection.Close();
            return num;
        }

        public string getDriverDueDate(int bookingID)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE BOOKING_ID = '" + bookingID + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string date = "";

            while (reader.Read())
            {
                date = reader.GetString(8);
            }
            connection.Close();
            return date;

        }

        public string getBookingDescription(int bookingID)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from BOOKINGS WHERE BOOKING_ID = '" + bookingID + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string Description = "";

            while (reader.Read())
            {

                Description = reader.GetString(4);

            }
            connection.Close();
            return Description;
        }

        /**/
        public List<String> getMaintanceVehicles()
        {

            List<string> Driver = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from VEHICLE WHERE VEHICLE_STATUS = 'Not Active'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

           
            while (reader2.Read())
            {
                Driver.Add(reader2.GetString(1));

            }

            connection.Close();

            return Driver;

        }

        /**/
        public void updateVehicleDimentions()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from VEHICLE", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                if (reader2.GetString(6) == "5")
                {
                    MySqlCommand command3 = new MySqlCommand("UPDATE set WEIGHT_SUPPORTED = '5000', VEHICLE_VOLUME_CM3 = '200000'", connection);
                    command3.ExecuteNonQuery();

                }
                if (reader2.GetString(6) == "10")
                {
                    MySqlCommand command3 = new MySqlCommand("UPDATE set WEIGHT_SUPPORTED = '10000', VEHICLE_VOLUME_CM3 = '450000'", connection);
                    command3.ExecuteNonQuery();

                }
                if (reader2.GetString(6) == "20")
                {
                    MySqlCommand command4 = new MySqlCommand("UPDATE set WEIGHT_SUPPORTED = '20000', VEHICLE_VOLUME_CM3 = '900000'", connection);
                    command4.ExecuteNonQuery();
                }

              }

            connection.Close();
            
        }

        //vehicle functions   
        public void AddVehicle(string Veh_reg, string Type, double Veh_Volume, double weight,
            double kilometer, DateTime ExperingDate, string Available, string status)
        {
            connection.ConnectionString = ConString;
            connection.Open();


            MySqlCommand command = new MySqlCommand("INSERT INTO VEHICLE(VEHICLE_REG ,VEHICLE_TYPE ,VEHICLE_VOLUME_CM3,WEIGHT_SUPPORTED,KILOMETERS_DRIVEN ,DISC_EXPIRY_DATE ,VEHICLE_AVAILABILITY,VEHICLE_STATUS, CURRENT_DRIVER ) VALUES "
               + "('" + Veh_reg + "','" + Type + "','" + Veh_Volume + "' , '" + weight + "','" + kilometer + "','" + ExperingDate + "','" + Available + "','" + status + "', 'No Driver')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool RemoveVehicle(string Registration_Num)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM VEHICLE WHERE VEHICLE_REG = '" + Registration_Num + "' ", connection);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        //public void GetAssignedVehicle()
        //{
        //    connection.ConnectionString = ConString;
            
        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand("SELECT * from BOOKINGS WHERE VEHICLE_REG = 'NONE'", connection);

        //    MySqlDataReader reader = command.ExecuteReader();
        //    double weight = 0;
        //    double volume = 0;
        //    int bookingId = 0;
        //    int DriverID = 0;
        //    while (reader.Read())
        //    {
                
        //        weight = reader.GetDouble(6);
        //        volume = reader.GetDouble(5);
        //        bookingId = reader.GetInt32(0);

            
        //        MySqlCommand command1 = new MySqlCommand("SELECT TOP 1 * from VEHICLE WHERE WEIGHT_SUPPORTED >= '" + weight + "'AND VEHICLE_VOLUME_CM3 >= '" + volume + "'", connection);
        //        MySqlDataReader reader1 = command1.ExecuteReader();
        //        int VehicleID = 0;
        //        string Vehicle_Reg = "";
        //        double ChangedWeight = 0;
        //        double ChangedVolume = 0;
               
        //        while (reader1.Read())
        //        {
        //            VehicleID = reader1.GetInt32(0);
        //            Vehicle_Reg = reader1.GetString(1);
        //            ChangedWeight = reader1.GetDouble(4) - weight;
        //            ChangedVolume = reader1.GetDouble(3) - volume;


        //            MySqlCommand command2 = new MySqlCommand("UPDATE VEHICLE SET WEIGHT_SUPPORTED = '" + ChangedWeight + "', VEHICLE_VOLUME_CM3='" + ChangedVolume + "' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
        //            command2.ExecuteNonQuery();


        //            MySqlCommand command3 = new MySqlCommand("UPDATE BOOKINGS SET VEHICLE_REG = '" + Vehicle_Reg + "', WHERE BOOKING_ID ='" + bookingId + "'", connection);
        //            command3.ExecuteNonQuery();
        //   //         AssignDriver(Vehicle_Reg);

                
        //            MySqlCommand command4 = new MySqlCommand("SELECT TOP 1 * FROM DRIVERS WHERE BOOKING_AVAILABILITY='True'", connection);
        //            MySqlDataReader reader4 = command4.ExecuteReader();

        //            while (reader4.Read())
        //            {
        //                DriverID = reader4.GetInt32(0);
        //            }
                 
        //            MySqlCommand command5 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'False', VEHICLE_ASSIGNED ='" + Vehicle_Reg + "'  WHERE DRIVER_ID ='" + DriverID + "'", connection);
        //            command5.ExecuteNonQuery();

        //        }

        //    }
        //    connection.Close();
        //}

        public void GetAssignedVehicle()
        {
            connection.ConnectionString = ConString;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                
            }
            MySqlCommand command = new MySqlCommand("SELECT * from BOOKINGS WHERE VEHICLE_REG = 'NONE'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<double> weightList = new List<double>();
            List<double> volumeList = new List<double>();
            List<int> bookingIdList = new List<int>();
            List<int> VehicleIDList = new List<int>();

            List<string> Vehicle_RegList = new List<string>();
            List<double> ChangedWeightList = new List<double>();
            List<double> ChangedVolumeList = new List<double>();

            List<int> DriverIDList = new List<int>(); 

            while (reader.Read())
            {

                weightList.Add(reader.GetDouble(6));
                volumeList.Add(reader.GetDouble(5));
                bookingIdList.Add(reader.GetInt32(0));
                
            }
            connection.Close(); 

            for(int i = 0; i < weightList.Count  ; i++)
            {
                connection.ConnectionString = ConString;
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT * from VEHICLE WHERE WEIGHT_SUPPORTED >= '" + weightList[i] + "'AND VEHICLE_VOLUME_CM3 >= '" + volumeList[i] + "' LIMIT 1", connection);
                MySqlDataReader reader1 = command1.ExecuteReader();

               
                while (reader1.Read())
                {
                    VehicleIDList.Add(reader1.GetInt32(0));
                    Vehicle_RegList.Add(reader1.GetString(1));
                    ChangedWeightList.Add(reader1.GetDouble(4) - weightList[i]);
                    ChangedVolumeList.Add(reader1.GetDouble(3) - volumeList[i]);

                }
                connection.Close();

                for (int e = 0; e < VehicleIDList.Count ; e++)
                {
                    connection.ConnectionString = ConString;
                    connection.Open();
                    MySqlCommand command2 = new MySqlCommand("UPDATE VEHICLE SET WEIGHT_SUPPORTED = '" + ChangedWeightList[e] + "', VEHICLE_VOLUME_CM3='" + ChangedVolumeList[e] + "' WHERE VEHICLE_REG ='" + Vehicle_RegList[e] + "' ", connection);
                    command2.ExecuteNonQuery();


                    MySqlCommand command3 = new MySqlCommand("UPDATE BOOKINGS SET VEHICLE_REG = '" + Vehicle_RegList[e] + "' WHERE BOOKING_ID ='" + bookingIdList[i] + "'", connection);
                    command3.ExecuteNonQuery();
                    //         AssignDriver(Vehicle_Reg);


                    MySqlCommand command4 = new MySqlCommand("SELECT * FROM DRIVERS WHERE BOOKING_AVAILABILITY='True'  LIMIT 1", connection);
                    MySqlDataReader reader4 = command4.ExecuteReader();

                   
                    while (reader4.Read())
                    {
                        DriverIDList.Add(reader4.GetInt32(0));
                    }
                    connection.Close(); 

                    for (int r = 0; r < DriverIDList.Count ; e++)
                  {
                    connection.ConnectionString = ConString;
                    connection.Open();
                    MySqlCommand command5 = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'False', VEHICLE_ASSIGNED ='" + Vehicle_RegList[e] + "'  WHERE DRIVER_ID ='" + DriverIDList[r] + "'", connection);
                    command5.ExecuteNonQuery();
                  }
                }
             }
            connection.Close();
        }
       
        public void UpdateVehicleAvailability(string Vehicle_Reg)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET VEHICLE_AVAILABILITY = 'false' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public string ViewVehicles()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from VEHICLE ", connection);

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Vehicle ID </th>");
            html.Append("<th>Vehicle Registration </th>");
            html.Append("<th>Vehicle Type </th>");
            html.Append("<th>Vehivle Volume </th>");
            html.Append("<th>Vehicle weight </th>");
            html.Append("<th>Kilometers Driven</th>");
            html.Append("<th>Disc Expiry Date</th>");
            html.Append("<th>Vehicle Availability</th>");
            html.Append("<th>Vehicle Status</th>");
            html.Append("<th>Vehicle Checkout</th>");
            html.Append("<th>Problem report</th>");
            html.Append("<th>Vehicle size </th>");
            html.Append("<th> Current Driver</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();


        }

        /**/
        public string viewMaintanceVehicles()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from VEHICLE WHERE VEHICLE_STATUS = 'Not Active' ", connection);

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Vehicle ID </th>");
            html.Append("<th>Vehicle Registration </th>");
            html.Append("<th>Vehicle Type </th>");
            html.Append("<th>Vehivle Volume </th>");
            html.Append("<th>Vehicle weight </th>");
            html.Append("<th>Kilometers Driven</th>");
            html.Append("<th>Disc Expiry Date</th>");
            html.Append("<th>Vehicle Availability</th>");
            html.Append("<th>Vehicle Status</th>");
            html.Append("<th>Vehicle Checkout</th>");
            html.Append("<th>Problem report</th>");
            html.Append("<th>Vehicle size </th>");
            html.Append("<th> Current Driver</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();


        }

        /**/
        public string viewReportedVehicles()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from VEHICLE WHERE VEHICLE_REPORT <> 'NONE' ", connection);

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Vehicle ID </th>");
            html.Append("<th>Vehicle Registration </th>");
            html.Append("<th>Vehicle Type </th>");
            html.Append("<th>Vehivle Volume </th>");
            html.Append("<th>Vehicle weight </th>");
            html.Append("<th>Kilometers Driven</th>");
            html.Append("<th>Disc Expiry Date</th>");
            html.Append("<th>Vehicle Availability</th>");
            html.Append("<th>Vehicle Status</th>");
            html.Append("<th>Vehicle Checkout</th>");
            html.Append("<th>Reported Problem</th>");
            html.Append("<th>Vehicle size</th>");
            html.Append("<th> Current Driver</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        /**/
        public string viewDamagedVehicles()
        {
            return "";
        }

        /**/
        public string viewVehiclesExpiredPlate()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from VEHICLE WHERE DISC_EXPIRY_DATE < '" + System.DateTime.Now + "' ", connection);

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Vehicle ID </th>");
            html.Append("<th>Vehicle Registration </th>");
            html.Append("<th>Vehicle Type </th>");
            html.Append("<th>Vehivle Volume </th>");
            html.Append("<th>Vehicle weight </th>");
            html.Append("<th>Kilometers Driven</th>");
            html.Append("<th>Disc Expiry Date</th>");
            html.Append("<th>Vehicle Availability</th>");
            html.Append("<th>Vehicle Status</th>");
            html.Append("<th>Vehicle Checkout</th>");
            html.Append("<th>Vehicle Report</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }
         
        /**/
        public void UpdateVehicleActive(string Vehicle_Reg)
        {

            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET VEHICLE_STATUS = 'Active',  VEHICLE_REPORT='NONE' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        //report functions
        public int getWeeklySales(DateTime DT)
        {
            int statements = 0;

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from PRICING WHERE BOOKING_DATE =  '" + DT + "' ", connection);
            MySqlDataReader reader = command.ExecuteReader();

        //    int c = 0;
            while (reader.Read())
            {

                statements = statements + reader.GetInt32(5);
            }
            int dailPercentage = statements / 100000 * 100; //100000 is the daily average

            connection.Close();
            return dailPercentage;

        }

        public List<object> getBarData(string year)
        {
            int price_id = 0;
            List<object> iData = new List<object>();
            List<string> labels = new List<string>();
            //First get distinct Month Name for select Year.
            string query1 = "Select distinct( DateName( month , DateAdd( month , DATEPART(MONTH,BOOKING_DATE) , -1 ) )) as month_name, ";
            query1 += " DATEPART(MONTH,BOOKING_DATE) as month_number from PRICING  where DATEPART(YEAR,BOOKING_DATE)='" + year + "'  ";
            query1 += " order by month_number;";

            DataTable dtLabels = commonFuntionGetData(query1);
            foreach (DataRow drow in dtLabels.Rows)
            {
                labels.Add(drow["month_name"].ToString());
            }
            iData.Add(labels);

            string query_DataSet_1 = " select DATENAME(MONTH,DATEADD(MONTH,month(BOOKING_DATE),-1 )) as month_name, month(BOOKING_DATE) as month_number ,sum ";
            query_DataSet_1 += " (ITEM_QUANTITY) as total_quantity  from PRICING  ";
            query_DataSet_1 += " where YEAR(BOOKING_DATE)='" + year + "' and  PRICING_ID ='" + price_id + "'  ";
            query_DataSet_1 += " group by   month(BOOKING_DATE) ";
            query_DataSet_1 += " order by  month_number  ";

            DataTable dtDataItemsSets_1 = commonFuntionGetData(query_DataSet_1);
            List<int> lst_dataItem_1 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_1.Rows)
            {
                lst_dataItem_1.Add(Convert.ToInt32(dr["total_quantity"].ToString()));
            }
            iData.Add(lst_dataItem_1);

            string query_DataSet_2 = " select DATENAME(MONTH,DATEADD(MONTH,month(BOOKING_DATE),-1 )) as month_name, month(BOOKING_DATE) as month_number ,sum ";
            query_DataSet_2 += " (ITEM_QUANTITY) as total_quantity  from PRICING ";
            query_DataSet_2 += " where YEAR(BOOKING_DATE)='" + year + "' and  PRICING_ID ='" + price_id + "'  ";
            query_DataSet_2 += " group by   month(BOOKING_DATE) ";
            query_DataSet_2 += " order by  month_number  ";

            DataTable dtDataItemsSets_2 = commonFuntionGetData(query_DataSet_2);
            List<int> lst_dataItem_2 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_2.Rows)
            {
                lst_dataItem_2.Add(Convert.ToInt32(dr["total_quantity"].ToString()));
            }
            iData.Add(lst_dataItem_2);
            return iData;
        }

        public DataTable commonFuntionGetData(string strQuery)
        {
            MySqlDataAdapter dap = new MySqlDataAdapter(strQuery, connection);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds.Tables[0];
        }

        public int getInformation()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            int projection = 0;
            int numMonths = 0;

            MySqlCommand command2 = new MySqlCommand("SELECT ITEM_PRICE_RANDS FROM PRICING WHERE ITEM_PRICE_RANDS =" + projection, connection);
            command2.ExecuteNonQuery();
            MySqlDataReader reader = command2.ExecuteReader();

            while (reader.Read())
            {
                projection = projection + reader.GetInt32(5);
            }

            int yearlyAmount = projection * numMonths; //this is to determine the sales at any given time

            connection.Close();
            return yearlyAmount;
        }

        public int getData()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            int price = 0;

            MySqlCommand command = new MySqlCommand("SELECT SUM(ITEM_PRICE_RANDS) AS TOTAL, ITEM_QUANTITY FROM PRICING GROUP BY ITEM_PRICE_RANDS" + price, connection);
            command.ExecuteNonQuery();

            connection.Close();
            return price;
        }

        public int getData1()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            int price = 0;

            MySqlCommand command = new MySqlCommand("SELECT ITEM_PRICE_RANDS FROM PRICING WHERE ITEM_PRICE_RANDS = " + price, connection);
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                price = price + reader.GetInt32(5);
            }

            connection.Close();
            return price;
        }

        public int getServiceInformation(DateTime date)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            int kilometres = 0;
            int numMonths = 0;

            MySqlCommand command2 = new MySqlCommand("SELECT KILOMETERS_DRIVEN FROM VEHICLE WHERE KILOMETERS_DRIVEN =" + kilometres, connection);
            command2.ExecuteNonQuery();
            MySqlDataReader reader = command2.ExecuteReader();

            while (reader.Read())
            {
                kilometres = kilometres + reader.GetInt32(5);
            }
            if (kilometres >= 200000)
            {
                MySqlCommand command = new MySqlCommand("UPDATE VEHICLE_STATUS FROM VEHICLE WHERE VEHICLE_STATUS =" + "false", connection);
                command.ExecuteNonQuery();
                MySqlDataReader reader2 = command2.ExecuteReader();
            }

            int yearlyAmount = kilometres * numMonths; //this is to determine the sales at any given time

            connection.Close();
            return yearlyAmount;
        }
		

        //manager functions
        public bool AddManager(string Name, string Surname, string UName, string Email,
            string Password, string ConfirmPassword, int UType, string Active)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            bool success = false;


            if (Password == ConfirmPassword)
            {
                string hashPassword = HashPassword(Password);
                MySqlCommand command = new MySqlCommand("INSERT INTO USERS(NAME , SURNAME , USERNAME ,  EMAIL ,USER_PASSWORD , USER_TYPE , ACTIVE_USER) VALUES "
                   + "('" + Name + "','" + Surname + "','" + UName + "' , '" + Email + "','" + hashPassword + "','" + UType + "','" + Active + "')", connection);

                command.ExecuteNonQuery();

                success = true;
            }
            else if (Password != ConfirmPassword)
            {
                success = false;
            }

            connection.Close();
            return success;
        }
        
        /**/
        public string ViewOrders()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from BOOKINGS", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Booking ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Collection Address</th>");
            html.Append("<th>Delivery Address</th>");
            html.Append("<th>Package Description</th>");
            html.Append("<th>Item Weight(kg)</th>");
            html.Append("<th>Volume  </th>");
            html.Append("<th>Booking Date </th>");
            html.Append("<th>Due Date</th>");
            html.Append("<th>Requirement</th>");
            html.Append("<th>Package Status</th>");
            html.Append("<th>Collection Date </th>");
            html.Append("<th>Delivery Date </th>");
            html.Append("<th>Vehicle Registration </th>");
      /**/  html.Append("<th>Booking Description</th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        /**/
        public string ViewAllPendingOrders()
        {
            connection.ConnectionString = ConString;
            connection.Open();
            DataSet dataSet = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM BOOKINGS WHERE STATUS = 'In Progress'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-striped' cellspacing='0' width='100%' style='grid-row-align:center; grid-column-align:center;'>");

            //Building the Header row.
            html.Append("<tr>");
            html.Append("<th>Booking ID</th>");
            html.Append("<th>Username</th>");
            html.Append("<th>Collection Address</th>");
            html.Append("<th>Delivery Address</th>");
            html.Append("<th>Package Type</th>");
            html.Append("<th>Item Weight(kg)</th>");
            html.Append("<th>Volume(m^3) </th>");
            html.Append("<th>Booking Date </th>");
            html.Append("<th>Due Date</th>");
            html.Append("<th>Requirement</th>");
            html.Append("<th>Package Status</th>");
            html.Append("<th>Collection Date </th>");
            html.Append("<th>Delivery Date </th>");
            html.Append("<th>Vehicle Registration </th>");
            html.Append("<th>Booking Description </th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            connection.Close();
            //Table end.
            html.Append("</table>");
            return html.ToString();

        }

        public void Assign_Booking(int Booking_ID, int Driver_ID)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE DRIVERS SET BOOKING_AVAILABILITY = 'false' ,BOOKING_ID ='" + Booking_ID + "' WHERE DRIVER_ID = '" + Driver_ID + "'", connection);
            command.ExecuteNonQuery();

            MySqlCommand command2 = new MySqlCommand("UPDATE BOOKINGS SET STATUS = 'In progress' WHERE BOOKING_ID ='" + Booking_ID + "'", connection);
            command2.ExecuteNonQuery();
            connection.Close();
        }

        /**/
        public List<String> getDriverWaypoints(string username)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            List<string> num = new List<string>();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();
            string Vehicle = "";
            while (reader.Read())
            {
                Vehicle = reader.GetString(12);
            }

            connection.Close();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS WHERE VEHICLE_REG = '" + Vehicle + "'", connection);
            MySqlDataReader reader2 = command.ExecuteReader();
            while (reader2.Read())
            {
                num.Add(reader2.GetString(2));
                num.Add(reader2.GetString(3));
            }

            connection.Close();
            return num;
        }

     /*   public List<String> getMaintanceVehicles()
        {

            List<string> Driver = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from VEHICLE WHERE VEHICLE_STATUS = 'Not Active'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                Driver.Add(reader2.GetString(1));

            }

            connection.Close();

            return Driver;

        }*/

      
        //-----------------------------------------Android functions---------------------------------------------------

        public string Login(string username, string password)
        {

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UName = "";
            string UPassword = "";
            string Success = "False";

            while (reader.Read())
            {

                UName = reader.GetString(3);
                UPassword = reader.GetString(5);


                if (UName == username)
                {

                    if (UPassword == HashPassword(password))
                    {
                        Success = "True";
                    }
                }
            }
            connection.Close();
            return Success;

        }

        public string GetVehicleReg(string Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            string vehicle = "";

            while (reader.Read())
            {

                vehicle = reader.GetString(12);

            }
            connection.Close();
            return vehicle;
        }
   
        public string ViewPending(string Vehicle_Reg)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select COLLECTION_ADR,DELIVERY_ADR,TYPE ,BOOKING_DATE,DUE_DATE,REQUIREMENT,STATUS,VEHICLE_REG,BOOKING_DESCRIPTION from BOOKINGS WHERE STATUS = 'In Progress' AND VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //  html.Append("<table>");
            html.Append("<table class='table table-bordered' width=\"50%\" >\n");

            //Building the Header row.
            html.Append("<tr>\n");
            html.Append("<th>Collection Address</th>\n");
            html.Append("<th>Delivery Address</th>\n");
            html.Append("<th>Package Description</th>\n");
            html.Append("<th>Booking Date</th>\n ");
            html.Append("<th>Due Date</th>\n");
            html.Append("<th>Requirement</th>\n");
            html.Append("<th>Package Status</th>\n");
            html.Append("<th>Vehicle Registration</th>\n");
            html.Append("<th>Booking Description</th></tr>\n");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>\n");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>\n");
                }
                html.Append("</tr>\n");
            }
            connection.Close();
            //Table end.
            //  html.Append("</table>");
            return html.ToString();

        }
  
        public string UpdateVehicleCheckOut(string Username, string Vehicle_Reg)
        {

            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET VEHICLE_AVAILABILITY = 'false', CURRENT_DRIVER = '" + Username + "', VEHICLE_CHECKOUT = 'Checked Out' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
            return "Checked Out";
        }

        public string UpdateVehicleCheckIn(string Username, string Vehicle_Reg)
        {

            connection.ConnectionString = ConString;
            connection.Open();
           
                     
            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET VEHICLE_AVAILABILITY = 'True', CURRENT_DRIVER = 'No Driver', VEHICLE_CHECKOUT = 'Checked In' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();

            MySqlCommand command2 = new MySqlCommand("UPDATE DRIVERS SET VEHICLE_ASSIGNED = 'NONE' WHERE DRIVER_USERNAME ='" + Username + "'", connection);
            command2.ExecuteNonQuery();

            connection.Close();
            return "Checked In";
        }

        public string UpdateCollection(string Booking_Description)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("UPDATE BOOKINGS SET STATUS = 'In Progress', COLLECTION_DATE ='" + System.DateTime.Now + "'  WHERE BOOKING_DESCRIPTION ='" + Booking_Description + "'", connection);
            command2.ExecuteNonQuery();
            connection.Close();

            return "Collected";

        }

        public string UpdateDelivery(string Booking_Description)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("UPDATE BOOKINGS SET STATUS = 'Delivered', DELIVERED_DATE ='" + System.DateTime.Now + "'  WHERE BOOKING_DESCRIPTION ='" + Booking_Description + "'", connection);
            command2.ExecuteNonQuery();
            connection.Close();

            return "Delivered";
        }

        public string UpdateLocation(string Username, double Lat, double Long)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE DRIVERS SET LATITUDE_COORDINATES = '" + Lat
                + "',LONGITUDE_COORDINATES = '" + Long + "' WHERE DRIVER_USERNAME ='" + Username + "'", connection);
            command.ExecuteNonQuery();

            connection.Close();

            return "Location Updated"; 


        }

        public string UpdateKilometers(string Vehicle_Reg, double Kilometers)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            double kilo = 0;
            MySqlCommand command2 = new MySqlCommand("select * from VEHICLE WHERE VEHICLE_REG ='" + Vehicle_Reg + "' ", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                kilo = reader2.GetDouble(5);

            }

            connection.Close();

            double totKilo = kilo + Kilometers;

            connection.Open();
            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET KILOMETERS_DRIVEN = '" + totKilo + "' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();

            return "Kilometers Updated"; 

        }

        public List<String> GetBookingDesciptions(string Vehicle_Reg)
        {
            List<string> Descriptions = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS WHERE VEHICLE_REG= '" + Vehicle_Reg + "' AND STATUS= 'In Progress'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                Descriptions.Add(reader2.GetString(14));

            }

            connection.Close();

            return Descriptions;
        }

        public List<String> GetCollectionAddresses(string Vehicle_Reg)
        {
            List<string> Descriptions = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS WHERE VEHICLE_REG= '" + Vehicle_Reg + "' AND STATUS= 'In Progress'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                Descriptions.Add(reader2.GetString(2));

            }

            connection.Close();

            return Descriptions;
        }

        public List<String> GetDeliveryAddresses(string Vehicle_Reg)
        {
            List<string> Descriptions = new List<string>();

            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS WHERE VEHICLE_REG= '" + Vehicle_Reg + "' AND STATUS= 'In Progress'", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {
                Descriptions.Add(reader2.GetString(3));

            }

            connection.Close();

            return Descriptions;
        }

        public string ReportProblem(string Vehicle_Reg, string Message)
        {
            connection.ConnectionString = ConString;
            connection.Open();

            MySqlCommand command = new MySqlCommand("UPDATE VEHICLE SET VEHICLE_REPORT = '" + Message + "', VEHICLE_STATUS = 'Not Active', VEHICLE_AVAILABILITY= 'false' WHERE VEHICLE_REG ='" + Vehicle_Reg + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();

            return "Reported";
        }


        //------------------------no longer needed-----------
        public string Registration(string Name, string Surname, string UName, string Email, string Password,
            string ConfirmPassword, int UType, string Active, string question, string ans)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            string success = "false";


            if (Password == ConfirmPassword)
            {
                string hashPassword = HashPassword(Password);
                MySqlCommand command = new MySqlCommand("INSERT INTO USERS(NAME , SURNAME , USERNAME ,  EMAIL ,USER_PASSWORD , USER_TYPE,ACTIVE_USER,S_QUESTION,S_ANSWER ) VALUES "
                   + "('" + Name + "','" + Surname + "','" + UName + "' , '" + Email + "','" + hashPassword + "','" + UType + "','" + Active + "','" + question + "','" + ans + "')", connection);

                command.ExecuteNonQuery();

                success = "true";
            }
            else if (Password != ConfirmPassword)
            {
                success = "false";
            }

            connection.Close();
            return success;
        }

        public string CheckExistinG(string name, string surname, string Username)
        {
            string exist = "false";
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from INACTIVE_USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string Name = "";
            string UserSuname = "";
            string UserName = "";

            while (reader.Read())
            {

                Name = reader.GetString(1);
                UserSuname = reader.GetString(2);
                UserName = reader.GetString(3);

                if (name == Name)
                {
                    if (surname == UserSuname)
                    {
                        if (Username == UserName)
                        {
                            exist = "true";
                        }
                    }
                }

            }

            connection.Close();

            return exist;
        }

        public string CheckExistingUName(string name, string surname, string Username)
        {
            string exist = "false";
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from USERS", connection);
            MySqlDataReader reader = command.ExecuteReader();


            string UserName = "";

            while (reader.Read())
            {
                UserName = reader.GetString(3);
                if (Username == UserName)
                {
                    exist = "true";
                }
            }

            connection.Close();

            return exist;
        }

        //public string UserType(string username, string password)
        //{
        //    connection.ConnectionString = ConString;
        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand("select * from USERS", connection);
        //    MySqlDataReader reader = command.ExecuteReader();

        //    string Username;
        //    string UName = "";
        //    string UPassword = "";
        //    int UserType = 0;
        //    string state = "Incorrect Details";
        //    string active = "";


        //    while (reader.Read())
        //    {

        //        UName = reader.GetString(3);
        //        UPassword = reader.GetString(5);
        //        UserType = reader.GetInt32(6);
        //        active = reader.GetString(7);

        //        if (UName == username)
        //        {

        //            if (UPassword == HashPassword(password))
        //            {

        //                if (UserType == 1) //user is a client
        //                {

        //                    state = "Client";
        //                    if (active == "false")
        //                    {
        //                        state = "Inactive";
        //                    }

        //                }

        //                else if (UserType == 2) //user is a driver
        //                {
        //                    state = "Driver";

        //                    if (active == "false")
        //                    {
        //                        state = "Inactive";
        //                    }

        //                }

        //            }
        //        }

        //    }

        //    connection.Close();
        //    return state;
        //}

       
        public string Booking(string User_Name, string Adress1, string Adress2, string Package_Type,
        double Package_Weight, double Package_Length,
        double Package_Breath, double Package_Height, int Item_Quantity,
            DateTime Delivery_DateNTime, string Requirement,
        string Delivery_stat, string dateCollected, string deliveredDate)
        {

            double tot = (Package_Weight * Item_Quantity);
            double volume = (Package_Length * Package_Breath * Package_Height) * Item_Quantity;
            double price = 0;
            string vehicle_Reg;
            DateTime Booking_Date = DateTime.Now;
            string Booking_Description = "";

            vehicle_Reg = "NONE";

            Booking_Description = User_Name + "-" + vehicle_Reg;


            if (tot < 500)
            {
                if (volume < 500000)
                {
                    price = (price + 1000);
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }
                    //van                    

                    price += price + 100;
                }
            }
            else if (tot > 500 && tot <= 1000)
            {
                if (volume > 500000 && volume <= 1000000)
                {
                    price = (price + 2000);
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }
                    //1ton
                    price += price + 200;
                }

            }
            else if (tot > 1000 && tot <= 5000)
            {
                if (volume > 1000000 && volume <= 2000000)
                {
                    price = (price + 3000);
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }

                }//5ton
                price += price + 300;
            }
            else if (tot >= 5000 && tot < 10000)
            {
                if (volume > 2000000 && volume <= 45000000)
                {
                    price = (price + 4000);
                    if (Requirement == "Refrigiration")
                    {
                        price += price * 0.1;
                    }
                    if (Requirement == "Heater")
                    {
                        price += price * 0.1;
                    }
                    //10ton
                    price += price + 400;

                }

                connection.ConnectionString = ConString;
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO BOOKINGS (USER_NAME, COLLECTION_ADR , DELIVERY_ADR ,TYPE," +
                                    " WEIGHT_KG,LENGTH_CM,BREATH_CM,HEIGHT_CM," +
                                    "QUANTITY, BOOKING_DATE,DUE_DATE,REQUIREMENT,STATUS,COLLECTION_DATE,DELIVERED_DATE, VEHICLE_ID, BOOKING_DESCRIPTION) VALUES "
                                    + "('" + User_Name + "','" + Adress1 + "','" + Adress2 + "' , '" + Package_Type
                                    + "','" + Package_Weight + "','" + Package_Length + "','" + Package_Breath
                                    + "','" + Package_Height + "', '" + Item_Quantity + "','" + Booking_Date + "','" + Delivery_DateNTime
                                    + "','" + Requirement + "','" + Delivery_stat + "','" + dateCollected + "','" + deliveredDate + "','" + vehicle_Reg + "', '" + Booking_Description + "')", connection);



                MySqlCommand command2 = new MySqlCommand("INSERT INTO PRICING(USER_NAME, REQUIREMENT, TOTAL_WEIGHT_KG, ITEM_QUANTITY, ITEM_PRICE_RANDS, BOOKING_DATE, DUE_DATE) VALUES "
                   + "('" + User_Name + "','" + Requirement + "','" + tot + "','" + Item_Quantity + "','" + price + "','" + Booking_Date + "','" + Delivery_DateNTime + "')", connection);

                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();

                //assigning booking to driver
              //  AssignBooking(User_Name, Booking_Date);


            }
            return "done";
        }

        public string ViewClientOrderss(string Username)
        {
            return "";
        }

        public string ViewStatements(string username)
        {
            return "";
        }

        
        public int GetBooking_ID(string Driver_Username)
        {
            connection.ConnectionString = ConString;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from DRIVERS WHERE DRIVER_USERNAME = '" + Driver_Username + "'", connection);
            MySqlDataReader reader = command.ExecuteReader();


            int booking_id = 0;
            string UName;

            while (reader.Read())
            {

                UName = reader.GetString(1);

                if (UName == Driver_Username)
                {
                    booking_id = reader.GetInt32(5);
                }
            }
            connection.Close();
            return booking_id;
        }

        //public string GetBookingDescription(int Booking_ID)
        //{
        //    string b = "";

        //    connection.ConnectionString = ConString;

        //    connection.Open();

        //    MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + Booking_ID + "'  ", connection);

        //    MySqlDataReader reader2 = command2.ExecuteReader();

        //    while (reader2.Read())
        //    {

        //        b = reader2.GetString(17);

        //    }

        //    connection.Close();
        //    return b; 
        //}

        public string GetOriginAddress(string Username)
        {

            int driverbID = 0;
            driverbID = getDriverBookingID(Username);
            connection.ConnectionString = ConString;
            connection.Open();

            string collectionAddress = "";
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + driverbID + "'  ", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                collectionAddress = reader2.GetString(2);

            }

            connection.Close();

            return collectionAddress;

        }

        public string GetDestinationAddress(string Username)
        {
            connection.ConnectionString = ConString;
            int driverbID = 0;
            driverbID = getDriverBookingID(Username);

            connection.Open();
            string Dest = "";
            MySqlCommand command2 = new MySqlCommand("select * from BOOKINGS  WHERE BOOKING_ID ='" + driverbID + "'  ", connection);

            MySqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {

                Dest = reader2.GetString(3);


            }

            connection.Close();

            return Dest;
        }

        //utility and test
        public string HashPassword(string pass)
        {
            SHA1 HashAlgorithm = SHA1.Create(); //Hash algorithm declaration
            Byte[] c; //Byte array to store the returned hashed data

            //Convert the input string to a byte array and compute the hash.
            c = HashAlgorithm.ComputeHash(Encoding.Default.GetBytes(pass));

            //String variable that will store the returned hashed string
            string hashedpass = "";

            //Loop through each byte of the hashed data and format each one as a hexadecimal string. 
            for (int i = 0; i < c.Length - 1; i++)
            {
                hashedpass += c[i].ToString("x2");
            }
            //Return the hexadecimal string. 
            return hashedpass;
        }

        public string GetDataUsingMethod(string username, string username2)
        {
            return username + username2 + " method";

        }

        public string GetString(string param)
        {
            connection.ConnectionString = ConString1;
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO Name(STRING) VALUES('" + param + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();

            return param;
        }


    }
}
