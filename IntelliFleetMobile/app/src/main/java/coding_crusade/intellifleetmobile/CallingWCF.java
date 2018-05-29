package coding_crusade.intellifleetmobile;

/**
 * Created by ObesT on 2016-08-07.
 */
public class CallingWCF {
    String server_response;
    private static StringBuilder result = new StringBuilder();
    private static String request = "";
    private static String response = "";
    private  static String res;

    public static String Registration(String Name, String Surname, String UName, String Email, String Password, String ConfirmPassword, int UType, String Active) {

        request = "http://192.168.43.137:3032/Service1.svc/Registration?Name=" + Name +
                "&Surname=" + Surname +
                "&UName=" + UName +
                "&Email=" + Email +
                "&Password=" + Password +
                "&ConfirmPassword=" + ConfirmPassword +
                "&UType=" + UType +
                "&Active=" + Active;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String Login(String username, String password) {
        request = "http://192.168.43.137:3032/Service1.svc/Login/" + username + "/" + password;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);


                String[] separated = s.split("\"");
                response = separated[3];
                res = response;
                System.out.println("----------------------- "+ response);
            }
        }.execute(request);

        return res;
    }

    public static String ViewPending(String Vehicle_Reg){
        request = "http://192.168.43.137:3032/Service1.svc/ViewPending/"+Vehicle_Reg;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String UpdateDelivery(String Booking_Description){

        request = "http://192.168.43.137:3032/Service1.svc/UpdateDelivery?Booking_ID=" + Booking_Description ;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

            }
        }.execute(request);

        return response;
    }

    public static String UpdateCollection(String Booking_Description){

        request = "http://192.168.43.137:3032/Service1.svc/UpdateCollection?Booking_ID=" + Booking_Description ;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String GetVehicleReg(String Username){

        request = "http://192.168.43.137:3032/Service1.svc/GetVehicleReg/" + Username ;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String UpdateVehicleCheckIn(String Username, String Vehicle_reg){

       request = "http://192.168.43.137:3032/Service1.svc/UpdateVehicleCheckIn/" + Username + "/" + Vehicle_reg ;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String UpdateVehicleCheckOut(String Username, String Vehicle_reg){

      //  request = "http://127.0.0.1:8000/Service1.svc/UpdateVehicleCheckOut/" + Username + "/" + Vehicle_reg ;

        request = "http://192.168.43.137:3032/Service1.svc/UpdateVehicleCheckOut/" + Username + "/" + Vehicle_reg ;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static void UpdatePosition(String Username, double Lat, double Long){
        request = "http://192.168.43.137:3032/Service1.svc/UpdateLocation?Username=" + Username +"&Lat="+Lat+"&Long="+Long ;

        System.out.println(request);

        new connection().execute(request);

    }

    public static void UpdateKilometers(String Vehicle_Reg, double Kilometers)
    {
        request = "http://192.168.43.137:3032/Service1.svc/UpdateKilometers?Vehicle_Reg = "+ Vehicle_Reg+"& Kilometers = "+Kilometers;
        new connection().execute(request);
    }

    public static void GetString(String param) {

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                System.out.println(separated[3]);

            }
        }.execute("http://192.168.43.137:3032/Service1.svc/GetString/" + param);
   }

    public static String GetUsername(String username, String password) {
        request = "http://192.168.43.137:3032/Service1.svc/GetUsername/" + username + "/" + password;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                response = separated[3];

            }
        }.execute(request);

        return response;
    }

    public static String CheckExistinG(String name, String surname, String Username) {
        request = "http://192.168.43.137:3032/Service1.svc/CheckExistinG/" + name + "/" + surname + "/" + Username;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                response = separated[3];
            }
        }.execute(request);

        return response;
    }

    public static String CheckExistingUName(String name, String surname, String Username) {
        request = "http://192.168.43.137:3032/Service1.svc/CheckExistingUName/" + name + "/" + surname + "/" + Username;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                response = separated[3];

            }
        }.execute(request);
        return response;
    }

    public static String ViewStatement(String username){
        request = "http://192.168.43.137:3032/Service1.svc/ViewStatement/"+ username;

        System.out.println(request);

        new connection(){
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);
                response = s;
            }
        }.execute(request);

        return response;
    }

    public static String GetOriginAddress (String Username)
    {
        request = "http://192.168.43.137:3032/Service1.svc/GetOriginAddress/" +Username;

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                response = separated[3];

            }
        }.execute(request);

        return response;

    }

    public static String GetDestinationAddress (String Username)
    {
        request = "http://192.168.43.137:3032/Service1.svc/GetDestinationAddress/" +Username;
        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);
                System.out.println(s);

                String[] separated = s.split("\"");
                response = separated[3];

            }
        }.execute(request);

        return response;
    }
}