package coding_crusade.intellifleetmobile;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

/**
 * A login screen that offers login via email/password.
 */
public class LoginActivity extends AppCompatActivity {// implements LoaderCallbacks<Cursor> {
    // Email, password edittext
    EditText txtUsername, txtPassword;

    // login button
    Button btnLogin;

    // Alert Dialog Manager
    AlertDialogManager alert = new AlertDialogManager();

    // Session Manager Class
    private SessionManager session;
    private SessionManager session2;
    private SessionManager session3;
    private SessionManager session4;
    private String UName = "";
    private String Login = "";
    private String Vehicle_Reg = "";
    private ProgressDialog pd;
    private String username;
    private String password;
    private String Deliveries;
    private String request = "";
    private String response = "";


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        // Session Manager
        session = new SessionManager(getApplicationContext());
        session2 = new SessionManager(getApplicationContext());
        session3 = new SessionManager(getApplicationContext());
        session4 = new SessionManager(getApplicationContext());

        // Email, Password input text
        txtUsername = (EditText) findViewById(R.id.email);
        txtPassword = (EditText) findViewById(R.id.password);

        // Login button
        btnLogin = (Button) findViewById(R.id.email_sign_in_button);

        // Login button click event
        btnLogin.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {
                // Get username, password from EditText
                username = txtUsername.getText().toString();
                password = txtPassword.getText().toString();

                pd = ProgressDialog.show(LoginActivity.this, "Please Wait...", "Logging in...", false, true);
                pd.setCanceledOnTouchOutside(false);

                // Check if username, password is filled
                if (username.trim().length() > 0 && password.trim().length() > 0) {

                    request = "http://192.168.43.137:3032/Service1.svc/Login/" + username + "/" + password;

                    System.out.println(request);

                    new connection() {
                        @Override
                        public void onResponse(String s) {
                            super.onResponse(s);


                            String[] separated = s.split("\"");
                            response = separated[3];
                            Login = response;
                            System.out.println("----------------------- "+ Login);
                        }
                    }.execute(request);

                    request = "http://192.168.43.137:3032/Service1.svc/GetVehicleReg/" + username ;

                    System.out.println(request);

                    new connection(){
                        @Override
                        public void onResponse(String s) {
                            super.onResponse(s);

                            String[] separated = s.split("\"");
                            response = separated[3];
                            Vehicle_Reg = response;
                            System.out.println("----------------------- "+ Vehicle_Reg);
                        }
                    }.execute(request);

                      Deliveries = "<table class='table table-bordered' width=\"50%\" >\n" +
                            "<tr>\n" +
                            "<th width=\"50%\">Collection Address</th>\n" +
                            "<th>Delivery Address</th>\n" +
                            "<th>Package Description<th>Booking Date</th>\n" +
                            "<th>Due Date<th>Requirement</th>\n" +
                            "<th>Vehicle Registration</th>\n" +
                            "<th>Booking Description</th></tr>\n" +
                            "<tr>\n<td>21 Kingsway Avenue,Johannesburg,2092</td>\n" +
                            "<td>0B Akademie Road,Johannesburg ,2092</td>\n" +
                            "<td>Boxes</td>\n" +
                            "<td>2016-11-08 13:28:37</td>\n" +
                            "<td>2016-11-09 14:00:00</td>\n" +
                            "<td>None</td>\n" +
                            "<td>BB12AAGP</td>\n" +
                            "<td>ThaboMokoena-Boxes</td>\n"+
                              "<tr>\n<td>12 Ditton Avenue ,Johannesburg ,2092</td>\n" +
                              "<td>157 Perth Road, Johannesburg, 2092</td>\n" +
                              "<td>Food</td>\n" +
                              "<td>2016-11-08 14:06:16</td>\n" +
                              "<td>2016-11-09 15:00:00</td>\n" +
                              "<td>Refrigiration</td>\n" +
                              "<td>BB12AAGP</td>\n" +
                              "<td>FayKarolia-Food</td>\n";

                    Thread t = new Thread() {
                        @Override
                        public void run() {
                            try {

                                Looper.prepare();

                                sleep(2000);  //Delay of 20 seconds

                            } catch (Exception e) {
                            } finally {

                                pd.dismiss();

                                System.out.println("----------------------- " + Login );
                                System.out.println("----------------------- " + Vehicle_Reg );

                                 if (Login.equals("True")) {
                                    session.createLoginSession(username, "Driver");
                                    session2.SetVehicle(Vehicle_Reg);
                                    session3.SetDeliveries(Deliveries);
                                    session4.SetWorking("Not_Working");

                                    // Staring MainActivity
                                    Intent i = new Intent(getApplicationContext(), MainActivity.class);
                                    startActivity(i);
                                }
                                else {
                                    // username / password doesn't match
                                    alert.showAlertDialog(LoginActivity.this, "Login failed..", "Username/Password is incorrect", false);
                                }
                            }
                        }
                    };t.start();
                } else {
                    // user didn't entered username or password
                    // Show alert asking him to enter the details
                    alert.showAlertDialog(LoginActivity.this, "Login failed..", "Please enter username and password", false);
                    pd.dismiss();
                }
            }
        });
    }

    @Override
    public void onBackPressed() {super.onBackPressed();}
}































 /*

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        // Set up the login form.
        mEmailView = (AutoCompleteTextView) findViewById(R.id.email);
        populateAutoComplete();

        mPasswordView = (EditText) findViewById(R.id.password);
        mPasswordView.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                if (id == R.id.login || id == EditorInfo.IME_NULL) {
                    attemptLogin();
                    return true;
                }
                return false;
            }
        });

        Button mEmailSignInButton = (Button) findViewById(R.id.email_sign_in_button);
        mEmailSignInButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin();
            }
        });

        Button Register = (Button)findViewById(R.id.btnRegister);
        intent = new Intent(this, Activity_Registration.class);

        Register.setOnClickListener(
                new Button.OnClickListener() {
                    public void onClick(View v) {
                        startActivity(intent);
                    }
                });

                        mLoginFormView = findViewById(R.id.login_form);
        mProgressView = findViewById(R.id.login_progress);


    }

    private void populateAutoComplete() {
        if (!mayRequestContacts()) {
            return;
        }

        if (VERSION.SDK_INT >= 14) {
            // Use ContactsContract.Profile (API 14+)
            getLoaderManager().initLoader(0, null, this);
        } else if (VERSION.SDK_INT >= 8) {
            // Use AccountManager (API 8+)
            new SetupEmailAutoCompleteTask().execute(null, null);
        }
    }

    private boolean mayRequestContacts() {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) {
            return true;
        }
        if (checkSelfPermission(READ_CONTACTS) == PackageManager.PERMISSION_GRANTED) {
            return true;
        }
        if (shouldShowRequestPermissionRationale(READ_CONTACTS)) {
            Snackbar.make(mEmailView, R.string.permission_rationale, Snackbar.LENGTH_INDEFINITE)
                    .setAction(android.R.string.ok, new View.OnClickListener() {
                        @Override
                        @TargetApi(Build.VERSION_CODES.M)
                        public void onClick(View v) {
                            requestPermissions(new String[]{READ_CONTACTS}, REQUEST_READ_CONTACTS);
                        }
                    });
        } else {
            requestPermissions(new String[]{READ_CONTACTS}, REQUEST_READ_CONTACTS);
        }
        return false;
    }

    *//**
     * Callback received when a permissions request has been completed.
     *//*
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions,
                                           @NonNull int[] grantResults) {
        if (requestCode == REQUEST_READ_CONTACTS) {
            if (grantResults.length == 1 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                populateAutoComplete();
            }
        }
    }

    *//**
     * Attempts to sign in or register the account specified by the login form.
     * If there are form errors (invalid email, missing fields, etc.), the
     * errors are presented and no actual login attempt is made.
     *//*
    private void attemptLogin() {
        if (mAuthTask != null) {
            return;
        }

        // Reset errors.
        mEmailView.setError(null);
        mPasswordView.setError(null);

        // Store values at the time of the login attempt.
        String email = mEmailView.getText().toString();
        String password = mPasswordView.getText().toString();

        System.out.println(email);
        System.out.println(password);

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(password) && validPassword==false) {
            mPasswordView.setError(getString(R.string.error_incorrect_password));
            focusView = mPasswordView;
            cancel = true;
        }
        if (TextUtils.isEmpty(password)) {
            mPasswordView.setError(getString(R.string.error_field_required));
            focusView = mPasswordView;
            cancel = true;
        }

        // Check for a valid email address.
        if (TextUtils.isEmpty(email)) {
            mEmailView.setError(getString(R.string.error_field_required));
            focusView = mEmailView;
            cancel = true;

        } else if (validEmail == false) {
            mEmailView.setError(getString(R.string.error_invalid_email));
            focusView = mEmailView;
            cancel = true;
        }

        if (cancel) {
            // There was an error; don't attempt login and focus the first
            // form field with an error.
            focusView.requestFocus();
        } else {
            // Show a progress spinner, and kick off a background task to
            // perform the user login attempt.
            showProgress(true);
            mAuthTask = new UserLoginTask(email, password);
            mAuthTask.execute((Void) null);
             intent = new Intent(this, MainActivity.class);
              startActivity(intent);


        }
    }

    private boolean isEmailValid(String email) {
        //TODO: Replace this with your own logic
        //   return email.contains("@");

        if (email.equals("Client1")) {

            validEmail = true;
        }else if(email.equals("Driver1"))
        {
            validEmail = true;
        }
        else {
            validEmail = false;
        }
        return validEmail;
//        return true;
    }

    private boolean isPasswordValid(String password) {
        //TODO: Replace this with your own logic
       // return password.length() > 4;
          boolean valid;
        if (password.equals("12345")) {
            valid = true;
        }
        else {
            valid = false;
        }
        return valid;

    }

    *//**
     * Shows the progress UI and hides the login form.
     *//*
    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    private void showProgress(final boolean show) {
        // On Honeycomb MR2 we have the ViewPropertyAnimator APIs, which allow
        // for very easy animations. If available, use these APIs to fade-in
        // the progress spinner.
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = getResources().getInteger(android.R.integer.config_shortAnimTime);

            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            mLoginFormView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);

                }
            });

            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mProgressView.animate().setDuration(shortAnimTime).alpha(
                    show ? 1 : 0).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
                }
            });

        } else {
            // The ViewPropertyAnimator APIs are not available, so simply show
            // and hide the relevant UI components.
            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);

        }

      //  intent = new Intent(this, MainActivity.class);
     //   startActivity(intent);

    }

    @Override
    public Loader<Cursor> onCreateLoader(int i, Bundle bundle) {
        return new CursorLoader(this,
                // Retrieve data rows for the device user's 'profile' contact.
                Uri.withAppendedPath(ContactsContract.Profile.CONTENT_URI,
                        ContactsContract.Contacts.Data.CONTENT_DIRECTORY), ProfileQuery.PROJECTION,

                // Select only email addresses.
                ContactsContract.Contacts.Data.MIMETYPE +
                        " = ?", new String[]{ContactsContract.CommonDataKinds.Email
                .CONTENT_ITEM_TYPE},

                // Show primary email addresses first. Note that there won't be
                // a primary email address if the user hasn't specified one.
                ContactsContract.Contacts.Data.IS_PRIMARY + " DESC");
    }

    @Override
    public void onLoadFinished(Loader<Cursor> cursorLoader, Cursor cursor) {
        List<String> emails = new ArrayList<>();
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            emails.add(cursor.getString(ProfileQuery.ADDRESS));
            cursor.moveToNext();
        }

        addEmailsToAutoComplete(emails);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> cursorLoader) {

    }

    private void addEmailsToAutoComplete(List<String> emailAddressCollection) {
        //Create adapter to tell the AutoCompleteTextView what to show in its dropdown list.
        ArrayAdapter<String> adapter =
                new ArrayAdapter<>(LoginActivity.this,
                        android.R.layout.simple_dropdown_item_1line, emailAddressCollection);

        mEmailView.setAdapter(adapter);
    }

    private interface ProfileQuery {
        String[] PROJECTION = {
                ContactsContract.CommonDataKinds.Email.ADDRESS,
                ContactsContract.CommonDataKinds.Email.IS_PRIMARY,
        };

        int ADDRESS = 0;
        int IS_PRIMARY = 1;
    }

    *//**
     * Use an AsyncTask to fetch the user's email addresses on a background thread, and update
     * the email text field with results on the main UI thread.
     *//*
    class SetupEmailAutoCompleteTask extends AsyncTask<Void, Void, List<String>> {

        @Override
        protected List<String> doInBackground(Void... voids) {
            ArrayList<String> emailAddressCollection = new ArrayList<>();

            // Get all emails from the user's contacts and copy them to a list.
            ContentResolver cr = getContentResolver();
            Cursor emailCur = cr.query(ContactsContract.CommonDataKinds.Email.CONTENT_URI, null,
                    null, null, null);
            while (emailCur.moveToNext()) {
                String email = emailCur.getString(emailCur.getColumnIndex(ContactsContract
                        .CommonDataKinds.Email.DATA));
                emailAddressCollection.add(email);
            }
            emailCur.close();

            return emailAddressCollection;
        }

        @Override
        protected void onPostExecute(List<String> emailAddressCollection) {
            addEmailsToAutoComplete(emailAddressCollection);
        }
    }

    *//**
     * Represents an asynchronous login/registration task used to authenticate
     * the user.
     *//*
    public class UserLoginTask extends AsyncTask<Void, Void, Boolean> {

        private final String mEmail;
        private final String mPassword;

        UserLoginTask(String email, String password) {
            mEmail = email;
            mPassword = password;
        }

        @Override
        protected Boolean doInBackground(Void... params) {
            // TODO: attempt authentication against a network service.

            try {
                // Simulate network access.
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                return false;
            }

            for (String credential : DUMMY_CREDENTIALS) {
                String[] pieces = credential.split(":");
                if (pieces[0].equals(mEmail)) {
                    // Account exists, return true if the password matches.
                    return pieces[1].equals(mPassword);
                }
            }

            // TODO: register the new account here.
            return true;
        }

        @Override
        protected void onPostExecute(final Boolean success) {
            mAuthTask = null;
            showProgress(false);

            if (success) {
                finish();
            } else {
                mPasswordView.setError(getString(R.string.error_incorrect_password));
                mPasswordView.requestFocus();
            }
        }

        @Override
        protected void onCancelled() {
            mAuthTask = null;
            showProgress(false);
        }
    }
}

*/