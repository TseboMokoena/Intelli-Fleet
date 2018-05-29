package coding_crusade.intellifleetmobile;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

import java.util.HashMap;

public class Activity_Vehicle_CheckOut_CheckIn extends AppCompatActivity {

    private Intent intent1;
    private Intent intent2;

    private View focusView = null;
    private boolean cancel = false;
    private EditText vehicle_Reg;
	private  SessionManager session;
    private  SessionManager session2;
    private HashMap<String, String> user;
    private HashMap<String, String> user2;
	private String Username = "";
    private String V_Reg;
    private String working;
    private static String request = "";
    private static String response = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activity__vehicle__check_out__check_in);

        // Session class instance
        session = new SessionManager(getApplicationContext());
        session2 = new SessionManager(getApplicationContext());

        // get user data from session
        user = session.getUserDetails();
        user2 = session2.getUserDetails();

        session.checkLogin();

        Username = user.get(SessionManager.KEY_NAME);
        V_Reg = user.get(SessionManager.KEY_VEHICLE);
        working = user2.get(SessionManager.KEY_WORKING);

        vehicle_Reg = (EditText)findViewById(R.id.txtVehicleRegistration);

        vehicle_Reg.setText(V_Reg);

            Button checkout = (Button)findViewById(R.id.btnCheckOut);

            Button checkin = (Button)findViewById(R.id.btnCheckIn);

            intent1 = new Intent(this, Activity_Routing.class);
            intent2 = new Intent(this, MainActivity.class);

        if(working.equals("Not_Working"))
        {
            checkin.setVisibility(View.GONE);
        }
        else if(working.equals("Working"))
        {
            checkout.setVisibility(View.GONE);
        }

        checkin.setOnClickListener(
                new ImageButton.OnClickListener() {
                    public void onClick(View v) {

                        String x = vehicle_Reg.getText().toString();

                        if (TextUtils.isEmpty(x)) {
                            vehicle_Reg.setError(getString(R.string.error_field_required));
                            focusView = vehicle_Reg;
                            cancel = true;
                        }
                        else if (cancel) {
                            focusView.requestFocus();
                        }
                        else
                        {
                          //  System.out.println(x);
                          //  CallingWCF.UpdateVehicleCheckIn(Username, x);
                            request = "http://192.168.43.137:3032/Service1.svc/UpdateVehicleCheckIn/" + Username + "/" + x ;

                            System.out.println(request);

                            new connection(){
                                @Override
                                public void onResponse(String s) {
                                    super.onResponse(s);
                                    System.out.println(s);
                                    response = s;
                                }
                            }.execute(request);

                            Toast.makeText(getApplicationContext(), "Vehicle checked has been checked in. Jobs completed.", Toast.LENGTH_LONG).show();
                            startActivity(intent2);
                        }

                    }
                });

        checkout.setOnClickListener(
                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {

                            String x = vehicle_Reg.getText().toString();

                            if (TextUtils.isEmpty(x)) {
                                vehicle_Reg.setError(getString(R.string.error_field_required));
                                focusView = vehicle_Reg;
                                cancel = true;
                            }
                            else if (cancel) {
                                focusView.requestFocus();
                            }
                           else
                            {
                                session2.SetWorking("Working");
                                System.out.println(x);
                            //    CallingWCF.UpdateVehicleCheckOut(Username, x);

                                request = "http://192.168.43.137:3032/Service1.svc/UpdateVehicleCheckOut/" + Username + "/" + x ;

                                System.out.println(request);

                                new connection(){
                                    @Override
                                    public void onResponse(String s) {
                                        super.onResponse(s);
                                        System.out.println(s);
                                        response = s;
                                    }
                                }.execute(request);
                                Toast.makeText(getApplicationContext(), "Vehicle checked has been checked out", Toast.LENGTH_LONG).show();
                                startActivity(intent1);
                            }


                        }
                    });
        }

}
