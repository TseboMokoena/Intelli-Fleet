package coding_crusade.intellifleetmobile;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.util.HashMap;

public class Activity_Roadside_Assistance extends AppCompatActivity {
    private Intent intent1;
    private EditText problem_text;
    private  SessionManager session;
    private HashMap<String, String> user;
      private String V_Reg;
    private View focusView = null;
    private boolean cancel = false;
    private String request;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity__roadside__assistance);

        // Session class instance
        session = new SessionManager(getApplicationContext());

        // get user data from session
        user = session.getUserDetails();

        session.checkLogin();

        V_Reg = user.get(SessionManager.KEY_VEHICLE);

        Button btnproblem = (Button)findViewById(R.id.btnProblem);
        problem_text = (EditText)findViewById(R.id.txtProblem);

        intent1 = new Intent(this, MainActivity.class);

        btnproblem.setOnClickListener(
                new Button.OnClickListener() {
                    public void onClick(View v) {

                        String x = problem_text.getText().toString();

                        if (TextUtils.isEmpty(x)) {
                            problem_text.setError(getString(R.string.error_field_required));
                            focusView = problem_text;
                            cancel = true;
                        }
                        else if (cancel) {
                            focusView.requestFocus();
                        }
                        else
                        {
                            //  System.out.println(x);
                            //   CallingWCF.UpdateVehicleCheckIn(x);
                            request = "http://192.168.43.137:3032/Service1.svc/ReportProblem/"+V_Reg+"/"+x;

                            System.out.println(request);

                            new connection().execute(request);

                            Toast.makeText(getApplicationContext(), "Replacement vehicle is on the way.", Toast.LENGTH_LONG).show();
                            startActivity(intent1);
                        }

                    }
                });
    }
}
