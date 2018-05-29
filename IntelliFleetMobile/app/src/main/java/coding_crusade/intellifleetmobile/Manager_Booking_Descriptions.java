package coding_crusade.intellifleetmobile;

import java.util.ArrayList;

/**
 * Created by ObesT on 2016-10-12.
 */

public  class Manager_Booking_Descriptions {
    ArrayList<String> Booking_Descriptions;
    private static final Manager_Booking_Descriptions instance = new Manager_Booking_Descriptions();


    private Manager_Booking_Descriptions(){
        Booking_Descriptions = new ArrayList<String>();
        Booking_Descriptions.add("Client1-Boxes");
        Booking_Descriptions.add("Client2-Food");
    }

    public static Manager_Booking_Descriptions getInstance(){
        return instance;
    }

    public ArrayList<String> getBooking_Descriptions(){
        return Booking_Descriptions;
    }
}
