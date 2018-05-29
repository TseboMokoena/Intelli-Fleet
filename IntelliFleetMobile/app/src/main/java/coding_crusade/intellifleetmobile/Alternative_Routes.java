package coding_crusade.intellifleetmobile;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Looper;
import android.support.design.widget.Snackbar;
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
import java.util.List;
import java.util.Locale;

public class Alternative_Routes extends AppCompatActivity implements OnMapReadyCallback, LocationListener, View.OnClickListener, DirectionCallback {
    private Button btnRequestDirection;
    private GoogleMap Googlemap;
    private String serverKey = "AIzaSyDAmhMqwMh_htnUKxPFjCiZmVr6-eDwnvo";
    private LatLng origin;
    private LatLng destination;
    private String[] colors = {"#7fff7272", "#7f31c7c5", "#7fff8a00"};
    private LocationManager locationManagerCt;
    private ProgressDialog pd;
    private Location locationCt;
    private LatLng loc ;
    private LatLng currentPosition;
    private SessionManager session;
    private HashMap<String, String> user;
    private double kilo =0;
    private String Username;
    private String Vehicle_Reg;
    private Button btnUpCollec;
    private List<Address> fromLocationName2 = null;
    private List<Address> fromLocationName = null;
    private String ad;
    private String ad2;
    private Geocoder geocoder;
    private boolean isGPSEnabled;
    private boolean isNetworkEnabled;
    private static long MIN_TIME_BW_UPDATES = 30000;
    private static float MIN_DISTANCE_CHANGE_FOR_UPDATES = 10;
    private String[] separated;
    private String request = "";
    private String[] separated2;
    private String request2 = "";
    private  List<String> list1;
    private  List<String> list2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_routing_schedule);

        btnRequestDirection = (Button) findViewById(R.id.btn_request_direction);
        btnRequestDirection.setOnClickListener(this);

        ((SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map)).getMapAsync(this);

        btnUpCollec =  (Button) findViewById(R.id.btn_Update_Collect);

        btnUpCollec.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), Activity_UpdateCollection.class);
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


    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        //this.googleMap = googleMap;
        Googlemap = googleMap;

        //    locationManagerCt = (LocationManager) getSystemService(Context.LOCATION_SERVICE);

        try {
//            locationCt = new Location(locationManagerCt.getLastKnownLocation(LocationManager.GPS_PROVIDER));
            //  currentPosition = new LatLng(locationCt.getLatitude(), locationCt.getLongitude());
            currentPosition = getLocation();
            request = "http://192.168.43.137:3032/Service1.svc/UpdateLocation?Username=" + Username +"&Lat="+currentPosition.latitude+"&Long="+ currentPosition.longitude ;

            System.out.println(request);

         //   new connection().execute(request);

        }catch (SecurityException e) {}


        geocoder = new Geocoder(getApplicationContext(), Locale.getDefault());


        request = "http://192.168.43.137:3032/Service1.svc/GetCollectionAddresses/"+ Vehicle_Reg;

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);

                separated = s.split("\"");

            }
        }.execute(request);

        request2 = "http://192.168.43.137:3032/Service1.svc/GetDeliveryAddresses/"+ Vehicle_Reg;

        new connection() {
            @Override
            public void onResponse(String s) {
                super.onResponse(s);

                separated2 = s.split("\"");

            }
        }.execute(request2);


        // List list1 =  Manager_CollectionAddresses.getInstance().get_CollectionsAddresses();
        // String ad = list1.get(0).toString();
        //   String ad = "0B Akademie Road";
        //   String Origin = call.GetOriginAddress(Username);
        Thread t = new Thread() {
            @Override
            public void run() {
                try {

                    Looper.prepare();

                    sleep(2000);  //Delay of 15 seconds


                } catch (Exception e) {}
                finally {
                    list1 = new ArrayList<String>();
                    list2 = new ArrayList<String>();

                    if(separated != null) {
                        if (separated.length > 4) {

                            System.out.println("-----------------collection adress " + separated[3]);
                            list1.add(separated[3]);


                            ad = list1.get(0).toString();
                            System.out.println("-----------------collection adress " + ad);

                            try {
                                fromLocationName = geocoder.getFromLocationName(ad, 1);
                            } catch (Exception e) {
                            }

                            if (fromLocationName != null) {
                                if (fromLocationName.size() > 0) {
                                    double latitude = fromLocationName.get(0).getLatitude();
                                    double longitude = fromLocationName.get(0).getLongitude();

                                    origin = new LatLng(latitude, longitude);
                                    System.out.println("-----------------collection lat long " + origin.latitude + "-" + origin.longitude);
                                }
                            }
                        }
                    }

                    if(separated2 != null) {
                        if (separated2.length > 4) {

                            //   for (int i = 0; i < separated2.length; i++) {
                            //  if (counter < separated2.length) {
                            System.out.println("-----------------delivery adress " + separated2[3]);
                            list2.add(separated2[3]);
                            // counter = counter + 2;

                            ad2 = list2.get(0).toString();
                            System.out.println("-----------------delivery adress " + ad2);

                            try {
                                fromLocationName2 = geocoder.getFromLocationName(ad2, 1);
                            } catch (Exception e) {
                            }
                            //      }

                            if (fromLocationName2 != null) {
                                if (fromLocationName2.size() > 0) {
                                    double latitude = fromLocationName2.get(0).getLatitude();
                                    double longitude = fromLocationName2.get(0).getLongitude();

                                    destination = new LatLng(latitude, longitude);
                                }
                            }
                        }
                    }




                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if(currentPosition != null) {
                                if (origin != null) {
                                    Googlemap.moveCamera(CameraUpdateFactory.newLatLng(currentPosition));
                                    Googlemap.animateCamera(CameraUpdateFactory.newLatLngZoom(currentPosition, 15));
                                    Googlemap.addMarker(new MarkerOptions().position(currentPosition).snippet("This is the Driver's location").title("Driver's current loction"));


                                    GoogleDirection.withServerKey(serverKey)
                                            .from(currentPosition)
                                            .to(origin)
                                            .transportMode(TransportMode.DRIVING)
                                            .alternativeRoute(true)
                                            .execute(Alternative_Routes.this);
                                }
                            }
                        }
                    });


                }
            }
        };t.start();
    }

    @Override
    public void onClick(View v) {
        int id = v.getId();
        if (id == R.id.btn_request_direction) {
            requestDirection();
        }
    }

    public void requestDirection() {
        Snackbar.make(btnRequestDirection, "Direction Requesting...", Snackbar.LENGTH_SHORT).show();

    }

    @Override
    public void onDirectionSuccess(Direction direction, String rawBody) {
        Snackbar.make(btnRequestDirection, "Success with status : " + direction.getStatus(), Snackbar.LENGTH_SHORT).show();
        if (direction.isOK()) {
            Googlemap.addMarker(new MarkerOptions().position(origin).snippet("This is the collection location").title("Origin").icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_BLUE)));
            Googlemap.addMarker(new MarkerOptions().position(destination).snippet("This is the delivery location").title("Destination").icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_GREEN)));
            Googlemap.addMarker(new MarkerOptions().position(currentPosition).snippet("This is the Driver's location").title("Driver's current loction"));

            for (int i = 0; i < direction.getRouteList().size(); i++) {
                Route route = direction.getRouteList().get(i);
                String color = colors[i % colors.length];
                ArrayList<LatLng> directionPositionList = route.getLegList().get(0).getDirectionPoint();
                Googlemap.addPolyline(DirectionConverter.createPolyline(this, directionPositionList, 5, Color.parseColor(color)));
            }

            btnRequestDirection.setVisibility(View.GONE);
         /*   float [] dist = new float[1];
            Location.distanceBetween(currentPosition.latitude ,origin.latitude ,
                    currentPosition.longitude , origin.longitude ,dist);
            kilo = dist[0] * 0.0000001;

            CallingWCF.UpdateKilometers( Vehicle_Reg,  kilo);
*/
        }
    }

    @Override
    public void onDirectionFailure(Throwable t) {
        Snackbar.make(btnRequestDirection, t.getMessage(), Snackbar.LENGTH_SHORT).show();
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