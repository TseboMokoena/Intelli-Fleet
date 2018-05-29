package coding_crusade.intellifleetmobile;

import java.util.ArrayList;

/**
 * Created by ObesT on 2016-10-12.
 */

public class Manager_CollectionAddresses {
    ArrayList<String> CollectionAddresses;
    private String collectionAdress1 = "0B Akademie Road, Johannesburg, 2092";
    private String collectionAdress2 = "0B Akademie Road, Johannesburg, 2092";
    private static final Manager_CollectionAddresses instance = new Manager_CollectionAddresses();


    private Manager_CollectionAddresses(){
        CollectionAddresses = new ArrayList<String>();
        CollectionAddresses.add(collectionAdress1);
        CollectionAddresses.add(collectionAdress2);
    }

    public static Manager_CollectionAddresses getInstance(){
        return instance;
    }

    public ArrayList<String> get_CollectionsAddresses(){
        return CollectionAddresses;
    }
}
