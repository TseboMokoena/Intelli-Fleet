package coding_crusade.intellifleetmobile;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class Activity_UpdateDelivery extends AppCompatActivity {


    private Intent intent;
    private Intent intent2;
    private Spinner spinner;
    private static String request = "";
    private static String response = "";
    private List<String> list;
    private SessionManager session;
    private HashMap<String, String> user;
    private String Vehicle_Reg;
    private String Jobs;
    private ProgressDialog pd;
    private String[] separated;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__update_delivery);


        String Vehicle_Reg;
        session = new SessionManager(getApplicationContext());
        user = session.getUserDetails();

        Vehicle_Reg = user.get(SessionManager.KEY_VEHICLE);

        pd = ProgressDialog.show(this, "Please Wait...", "Loading List of jobs...", false, true);
        pd.setCanceledOnTouchOutside(false);

        //    list = Manager_Booking_Descriptions.getInstance().getBooking_Descriptions();

        request = "http://192.168.43.137:3032/Service1.svc/GetBookingDesciptions/"+ Vehicle_Reg;

        System.out.println(request);

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);

                separated = s.split("\"");

            }
        }.execute(request);

        spinner = (Spinner) findViewById(R.id.spinner);
        Thread t = new Thread() {
            @Override
            public void run() {
                try {

                    Looper.prepare();

                    sleep(2000);  //Delay of 15 seconds


                } catch (Exception e) {}
                finally {
                    pd.dismiss();

                    list = new ArrayList<String>();


                    int counter = 3;

                    if(separated != null) {
                        for (int i = 0; i < separated.length; i++) {
                            if (counter < separated.length) {
                                System.out.println("-----------------splits " + separated[counter]);
                                list.add(separated[counter]);
                                counter = counter + 2;
                            }

                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    addToList(list);
                                }
                            });

                        }
                    }


                }
            }
        };t.start();


        Button Collection = (Button)findViewById(R.id.btnUpdateDelivery);
        intent = new Intent(this, Activity_Back_To_Parking.class);
        intent2 = new Intent(this, Activity_Routing.class);

        Collection.setOnClickListener(
                new ImageButton.OnClickListener() {
                    public void onClick(View v) {

                    //    CallingWCF.UpdateDelivery(String.valueOf(spinner.getSelectedItem()));

                        request = "http://192.168.43.137:3032/Service1.svc/UpdateDelivery?Booking_Description=" + spinner.getSelectedItem() ;

                        System.out.println("-------------------------"+ request);

                        new connection(){
                            @Override
                            public void onResponse(String s) {
                                super.onResponse(s);
                                System.out.println(s);

                            }
                        }.execute(request);

                        Toast.makeText(getApplicationContext(), "Update delivery of: "+spinner.getSelectedItem()+" Successful", Toast.LENGTH_LONG).show();

                        Manager_Booking_Descriptions.getInstance().getBooking_Descriptions().remove(0);
                        Manager_DestinationAddresses.getInstance().get_DestinationAddresses().remove(0);
                        Manager_CollectionAddresses.getInstance().get_CollectionsAddresses().remove(0);


                        if ( Manager_Booking_Descriptions.getInstance().getBooking_Descriptions().size() > 0)
                       {
                            startActivity(intent2);
                       }
                        else {
                            
                            Toast.makeText(getApplicationContext(), "Return vehicle to parking area.", Toast.LENGTH_LONG).show();
                            startActivity(intent);
                        }

                    }

                });
    }


    public void addToList(List<String> List)
    {

        ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this,(android.R.layout.simple_spinner_dropdown_item),List);
        dataAdapter.setDropDownViewResource(R.layout.s_spinner_dropdown_item);
        spinner.setAdapter(dataAdapter);
    }

}

