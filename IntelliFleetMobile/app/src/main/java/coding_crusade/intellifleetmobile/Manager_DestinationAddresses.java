package coding_crusade.intellifleetmobile;

import java.util.ArrayList;

/**
 * Created by ObesT on 2016-10-12.
 */

public class Manager_DestinationAddresses {
    ArrayList<String> DestinationAddresses;
    private String DestinationAddresses1 = "21 Kingsway Avenue, Johannesburg";
    private String DestinationAddresses2 = "157 Perth Road, Johannesburg, 2092";
    private static final Manager_DestinationAddresses instance = new Manager_DestinationAddresses();

    private Manager_DestinationAddresses() {
        DestinationAddresses = new ArrayList<String>();
        DestinationAddresses.add(DestinationAddresses1);
        DestinationAddresses.add(DestinationAddresses2);
    }

    public static Manager_DestinationAddresses getInstance() {
        return instance;
    }

    public ArrayList<String> get_DestinationAddresses() {
        return DestinationAddresses;
    }
}
