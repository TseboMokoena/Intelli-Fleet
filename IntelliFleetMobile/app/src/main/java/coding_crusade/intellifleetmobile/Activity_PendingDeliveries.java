package coding_crusade.intellifleetmobile;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

import java.util.HashMap;

public class Activity_PendingDeliveries extends AppCompatActivity {
    private SessionManager session;
    private HashMap<String, String> user;



    Button BtnView;
    Button BtnWork;

  /*      private String Table = "<table class='table table-bordered' width=\"50%\" >\n" +
             "<tr>\n" +
             "<th width=\"50%\">Collection Address</th>\n" +
             "<th>Delivery Address</th>\n" +
             "<th>Package Description<th>Booking Date</th>\n" +
             "<th>Due Date<th>Requirement<th>Package Status</th>\n" +
             "<th>Vehicle Registration</th>\n" +
             "<th>Booking Description</th></tr>\n" +
             "<tr>\n<td>0B Akademie Road, Johannesburg, 2092</td>\n" +
             "<td>21 Kingsway Avenue, Johannesburg, 2092</td>\n" +
             "<td>boxes</td>\n" +
             "<td>2016-09-14 09:55:00 AM</td>\n" +
             "<td>2016-09-14 02:00:00 PM</td>\n" +
             "<td>None</td>\n" +
             "<td>In Progress</td>\n" +
             "<td>BB12AAGP</td>\n" +
             "<td>Client1-BB12AAGP</td>\n";*/

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__pending_deliveries);

        // Session class instance
        session = new SessionManager(getApplicationContext());

        // get user data from session
        user = session.getUserDetails();

        BtnView = (Button) findViewById(R.id.btnView);

        // Login button click event
        BtnView.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), Activity_View_Jobs.class);
                startActivity(i);
                finish();

            }
        });

        BtnWork = (Button) findViewById(R.id.btnStartWork);
        BtnWork.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), Activity_Vehicle_CheckOut_CheckIn.class);
                startActivity(i);
                finish();
            }
        });
    }

}
