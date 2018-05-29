package coding_crusade.intellifleetmobile;

import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Build;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.akexorcist.googledirection.DirectionCallback;
import com.akexorcist.googledirection.GoogleDirection;
import com.akexorcist.googledirection.constant.TransportMode;
import com.akexorcist.googledirection.model.Direction;
import com.akexorcist.googledirection.model.Route;
import com.akexorcist.googledirection.util.DirectionConverter;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import java.util.ArrayList;
import java.util.HashMap;
public class Activity_Back_To_Parking extends AppCompatActivity implements OnMapReadyCallback, LocationListener, DirectionCallback {

    private GoogleMap googleMap;
    private String serverKey = "AIzaSyDAmhMqwMh_htnUKxPFjCiZmVr6-eDwnvo";
    private LatLng Parking;
    private LatLng destination;
    private String[] colors = {"#7fff7272", "#7f31c7c5", "#7fff8a00"};
    private Location locationCt;
    private LocationManager locationManagerCt;
    private LocationListener listener;
    private LocationManager manager;
    private LatLng currentPosition;

    private SessionManager session;
    private HashMap<String, String> user;
    private HashMap<String, String> BookingContainer;
    private String Username;
    private String Vehicle_Reg;
    private double kilo =0;
    private Button Checkin;
    private boolean isGPSEnabled;
    private boolean isNetworkEnabled;
    private static long MIN_TIME_BW_UPDATES = 30000;
    private  static float MIN_DISTANCE_CHANGE_FOR_UPDATES = 10;
    private LatLng loc ;
    private String request = "";
    private String response = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_back__to__parking);
      //   btnRequestDirection = (Button) findViewById(R.id.btn_request_direction);
      // btnRequestDirection.setOnClickListener(this);

        ((SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map)).getMapAsync(this);

        Checkin =  (Button) findViewById(R.id.btnCheckIn);

        Checkin.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), Activity_Vehicle_CheckOut_CheckIn.class);
                startActivity(i);

            }
        });

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M)
        {
            if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this,  android.Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {

                requestPermissions(new String[]
                        {
                                android.Manifest.permission.ACCESS_FINE_LOCATION,  android.Manifest.permission.ACCESS_COARSE_LOCATION, android.Manifest.permission.INTERNET
                        },10);
            }

            return;
        }



        session = new SessionManager(getApplicationContext());
        user = session.getUserDetails();
        Username= user.get(SessionManager.KEY_NAME);
        Vehicle_Reg = user.get(SessionManager.KEY_VEHICLE);


       /* FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });*/


    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        this.googleMap = googleMap;

        //locationManagerCt = (LocationManager) getSystemService(Context.LOCATION_SERVICE);

        try {
         //   locationCt = new Location(locationManagerCt.getLastKnownLocation(LocationManager.GPS_PROVIDER));
            //  currentPosition = new LatLng(locationCt.getLatitude(), locationCt.getLongitude());
            currentPosition = getLocation();
           // CallingWCF.UpdatePosition(Username, currentPosition.latitude, currentPosition.longitude);

            request = "http://192.168.43.137:3032/Service1.svc/UpdateLocation?Username=" + Username +"&Lat="+currentPosition.latitude+"&Long="+ currentPosition.longitude ;
            new connection().execute(request);

        }catch (SecurityException e) {}

        Parking = new LatLng(-26.182361,27.997969);
        
        googleMap.moveCamera(CameraUpdateFactory.newLatLng(currentPosition));
        googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(currentPosition, 15));



        GoogleDirection.withServerKey(serverKey)
                .from(currentPosition)
                .to(Parking)
                .transportMode(TransportMode.DRIVING)
                .alternativeRoute(true)
                .execute(this);
    }

  /*  @Override
    public void onClick(View v) {
        int id = v.getId();
        if (id == R.id.btn_request_direction) {
            requestDirection();
        }
    }*/

    public void requestDirection() {
     //   Snackbar.make(btnRequestDirection, "Direction Requesting...", Snackbar.LENGTH_SHORT).show();

    }

    @Override
    public void onDirectionSuccess(Direction direction, String rawBody) {
    //    Snackbar.make(btnRequestDirection, "Success with status : " + direction.getStatus(), Snackbar.LENGTH_SHORT).show();
        if (direction.isOK()) {
            googleMap.addMarker(new MarkerOptions().position(Parking).snippet("This is the parking location").title("Parking").icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_BLUE)));
            googleMap.addMarker(new MarkerOptions().position(currentPosition).snippet("This is the Driver's location").title("Driver's current location"));

            for (int i = 0; i < direction.getRouteList().size(); i++) {
                Route route = direction.getRouteList().get(i);
                String color = colors[i % colors.length];
                ArrayList<LatLng> directionPositionList = route.getLegList().get(0).getDirectionPoint();
                googleMap.addPolyline(DirectionConverter.createPolyline(this, directionPositionList, 5, Color.parseColor(color)));
            }

        //   btnRequestDirection.setVisibility(View.GONE);
            float [] dist = new float[1];
            Location.distanceBetween(currentPosition.latitude ,Parking.latitude ,
                    currentPosition.longitude , Parking.longitude ,dist);
            kilo = dist[0] * 0.0000001;

         //   CallingWCF.UpdateKilometers( Vehicle_Reg,  kilo);
            request = "http://192.168.43.137:3032/Service1.svc/UpdateKilometers?Vehicle_Reg = "+ Vehicle_Reg+"& Kilometers = "+kilo;
            new connection().execute(request);

        }
    }

    @Override
    public void onDirectionFailure(Throwable t) {
    //   Snackbar.make(btnRequestDirection, t.getMessage(), Snackbar.LENGTH_SHORT).show();
    }


    @Override
    public void onLocationChanged(Location location) {}

    @Override
    public void onProviderDisabled(String provider) { }

    @Override
    public void onProviderEnabled(String provider) { }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) { }

    public LatLng getLocation() {

        try {
            locationManagerCt = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
            // getting GPS status
            isGPSEnabled = locationManagerCt.isProviderEnabled(LocationManager.GPS_PROVIDER);

            // getting network status
            isNetworkEnabled = locationManagerCt.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

            if (!isGPSEnabled && !isNetworkEnabled) {
                // no network provider is enabled
            } else {
                //   this.canGetLocation = true;
                if (isNetworkEnabled) {
                    try{
                        locationManagerCt.requestLocationUpdates(
                                LocationManager.NETWORK_PROVIDER,
                                MIN_TIME_BW_UPDATES,
                                MIN_DISTANCE_CHANGE_FOR_UPDATES,this);}
                    catch(SecurityException e){
                    }
                    Log.d("Network", "Network Enabled");
                    if (locationManagerCt != null) {
                        try {
                            locationCt = locationManagerCt.getLastKnownLocation(LocationManager.NETWORK_PROVIDER);
                        } catch (SecurityException e) {
                        }
                        if (locationCt != null) {
                            loc = new LatLng(locationCt.getLatitude(), locationCt.getLongitude());
                        }
                    }
                }
                // if GPS Enabled get lat/long using GPS Services
                if (isGPSEnabled) {
                    if (locationCt == null) {
                        try{
                            locationManagerCt.requestLocationUpdates(
                                    LocationManager.GPS_PROVIDER,
                                    MIN_TIME_BW_UPDATES,
                                    MIN_DISTANCE_CHANGE_FOR_UPDATES,this);}
                        catch(SecurityException e){
                        }
                        Log.d("GPS", "GPS Enabled");
                        if (locationManagerCt != null) {
                            if (locationManagerCt != null) {
                                try {
                                    locationCt = locationManagerCt.getLastKnownLocation(LocationManager.GPS_PROVIDER);
                                } catch (SecurityException e) {
                                }

                                if (locationCt != null) {
                                    loc = new LatLng(locationCt.getLatitude(), locationCt.getLongitude());
                                }
                            }
                        }
                    }
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return loc;
    }

}
