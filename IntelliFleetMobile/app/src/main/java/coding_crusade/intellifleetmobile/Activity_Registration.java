package coding_crusade.intellifleetmobile;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;


public class Activity_Registration extends AppCompatActivity {

    private Intent intent;
    private AlertDialogManager  alert = new AlertDialogManager();
    // UI references.
    private EditText Email;
    private EditText Name ;
    private EditText Surname;
    private EditText Username;
    private EditText Passoword;
    private EditText ConPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activity__registration);

        intent = new Intent(this, LoginActivity.class);

        Button Submit = (Button) findViewById(R.id.btnSubmit);
        Name = (EditText) findViewById(R.id.txtName);
        Surname = (EditText) findViewById(R.id.txtSurname);
        Username = (EditText) findViewById(R.id.txtUsername);
        Email = (EditText) findViewById(R.id.txtEmail);
        Passoword = (EditText) findViewById(R.id.txtPassword);
        ConPassword = (EditText) findViewById(R.id.txtConPassword);

        Submit.setOnClickListener(
          new ImageButton.OnClickListener() {
           public void onClick(View v) {
               // Reset errors.
               Email.setError(null);
               Passoword.setError(null);
               Name.setError(null);
               Surname.setError(null);
               Username.setError(null);
               ConPassword.setError(null);

               // Store values at the time of the login attempt.
               String name = Name.getText().toString();
               String surname = Surname.getText().toString();
               String username = Username.getText().toString();
               String email =Email.getText().toString();
               String passoword = Passoword.getText().toString();
               String conPassword = ConPassword.getText().toString();

               Button Submit = (Button) findViewById(R.id.btnSubmit);
               boolean cancel = false;
               View focusView = null;

               if (TextUtils.isEmpty(name)) {
                   Name.setError(getString(R.string.error_field_required));
                   focusView = Name;
                   cancel = true;
               }

               if (TextUtils.isEmpty(surname)) {
                   Surname.setError(getString(R.string.error_field_required));
                   focusView = Surname;
                   cancel = true;
               }

               if (TextUtils.isEmpty(username)) {
                   Username.setError(getString(R.string.error_field_required));
                   focusView = Username;
                   cancel = true;

               } if (TextUtils.isEmpty(passoword)) {
                   Passoword.setError(getString(R.string.error_field_required));
                   focusView = Passoword;
                   cancel = true;
               }

               if (TextUtils.isEmpty(conPassword)) {
                   ConPassword.setError(getString(R.string.error_field_required));
                   focusView = ConPassword;
                   cancel = true;
               }

               if(!passoword.equals(conPassword))
               {
                   ConPassword.setError("Passwords don't match.");
                   focusView = ConPassword;
                   cancel = true;
               }

               // Check for a valid email address.
               if (TextUtils.isEmpty(email)) {
                   Email.setError(getString(R.string.error_field_required));
                   focusView = Email;
                   cancel = true;

               } else if (isEmailValid(email) == false) {
                   Email.setError("Inavlid email address");
                   focusView = Email;
                   cancel = true;
               }

               if (cancel) {
                   // There was an error; don't attempt login and focus the first
                   // form field with an error.
                   focusView.requestFocus();
               } else {
                   int UType = 1;
                   String Active = "True";
                   CallingWCF.Registration(name,surname,username,email, passoword, conPassword,  UType,  Active);
                   alert.showAlertDialog(Activity_Registration.this, "Success", "Registered successfully", true);

                   startActivity(intent);
               }
           }


          }
        );

    }

    private boolean isEmailValid(String email) {
        //TODO: Replace this with your own logic
           return email.contains("@");

    }
}

