package coding_crusade.intellifleetmobile;

import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageButton;

import java.util.HashMap;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {
 
	private AlertDialogManager alert = new AlertDialogManager();
    private  SessionManager session;
    private HashMap<String, String> user;
    private String UserType;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LOCKED);
        // Session class instance
        session = new SessionManager(getApplicationContext());

           session.checkLogin();

            // get user data from session
            user = session.getUserDetails();

            UserType = user.get(SessionManager.KEY_USERTYPE);


            DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                    this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
            drawer.setDrawerListener(toggle);
            toggle.syncState();

            NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
            navigationView.setNavigationItemSelectedListener(this);


            final Intent intentMB;
            final Intent intentPS;
            final Intent intentPD;
            final Intent intentRS;
            final Intent intentCH;
            final Intent intentRA;

            intentMB = new Intent(this, Activity_UpdateCollection.class);
            intentPS = new Intent(this, Activity_UpdateDelivery.class);
            intentPD = new Intent(this, Activity_PendingDeliveries.class);
            intentRS = new Intent(this, Activity_Routing.class);
            intentCH = new Intent(this, Activity_Vehicle_CheckOut_CheckIn.class);
            intentRA = new Intent(this, Activity_Roadside_Assistance.class);

            ImageButton MB = (ImageButton)findViewById(R.id.btnMB);
            ImageButton VPS = (ImageButton)findViewById(R.id.btnVPS);
            ImageButton VPD = (ImageButton)findViewById(R.id.btnVPD);
            ImageButton VRS = (ImageButton)findViewById(R.id.btnVRS);
            ImageButton CH = (ImageButton)findViewById(R.id.btnCH);
            ImageButton btnRA = (ImageButton)findViewById(R.id.btnRA);

            MB.setOnClickListener(

                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {
                            if (UserType.equals("Driver"))
                            {
                                startActivity(intentMB);
                            }
                            else
                            {
                                alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to Drivers only. Login as a driver and try again", false);
                            }

                        }
                    }
            );

            VPS.setOnClickListener(
                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {
                            if (UserType.equals("Driver"))
                            {
                                startActivity(intentPS);

                            }
                            else
                            {
                                alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to Drivers only. Login as a driver and try again", false);
                            }
                        }
                    }
            );


            VPD.setOnClickListener(
                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {
                            if (UserType.equals("Driver"))
                            {
                                startActivity(intentPD);
                            }
                            else
                            {
                                alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                            }

                        }
                    }
            );


            VRS.setOnClickListener(
                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {

                            if (UserType.equals("Driver"))
                            {
                                startActivity(intentRS);
                            }
                            else
                            {
                                alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                            }
                        }
                    }
            );


            CH.setOnClickListener(
                    new ImageButton.OnClickListener() {
                        public void onClick(View v) {

                            if (UserType.equals("Driver"))
                            {
                                startActivity(intentCH);
                            }
                            else
                            {
                                alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                            }
                        }
                    }
            );

        btnRA.setOnClickListener(
                new ImageButton.OnClickListener() {
                    public void onClick(View v) {

                        if (UserType.equals("Driver"))
                        {
                            startActivity(intentRA);
                        }
                        else
                        {
                            alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                        }
                    }
                }
        );


    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
            session.logoutUser();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        Intent intentSign;
        intentSign = new Intent(this, LoginActivity.class);


        if (id == R.id.action_settings) {
            return true;
        }
       else if (id == R.id.Signout) {
            onBackPressed();
            session.logoutUser();
           return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        Intent intent;

            //Driver operations
             if (id == R.id.PendingDeliveries) {
                if (UserType.equals("Driver"))
                {
                    intent = new Intent(this, Activity_PendingDeliveries.class);
                    startActivity(intent);
                }
                else
                {
                    alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                }
            }
            else if (id == R.id.UpdateCollection) {

                if (UserType.equals("Driver"))
                {
                    intent = new Intent(this, Activity_UpdateCollection.class);
                    startActivity(intent);
                }
                else
                {
                    alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                }
            }
            else if (id == R.id.UpdateDelivery) {
                if (UserType.equals("Driver"))
                {
                    intent = new Intent(this, Activity_UpdateDelivery.class);
                    startActivity(intent);
                }
                else
                {
                    alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                }
            }
            else if (id == R.id.RoutingSchedule) {

                if (UserType.equals("Driver")) {
                    intent = new Intent(this, Activity_Routing.class);
                    startActivity(intent);
                } else {
                    alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                }
            }
            else if (id == R.id.CheckInOut) {

                    if (UserType.equals("Driver"))
                    {
                        intent = new Intent(this, Activity_Vehicle_CheckOut_CheckIn.class);
                        startActivity(intent);
                    }
                    else
                    {
                        alert.showAlertDialog(MainActivity.this, "Inavlid user.", "This action is applicable to drivers only. Login as a driver and try again", false);
                    }
            }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
