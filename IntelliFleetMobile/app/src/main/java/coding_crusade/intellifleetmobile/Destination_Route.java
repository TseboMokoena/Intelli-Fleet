package coding_crusade.intellifleetmobile;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Looper;
import android.support.v4.app.FragmentActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.akexorcist.googledirection.DirectionCallback;
import com.akexorcist.googledirection.GoogleDirection;
import com.akexorcist.googledirection.constant.TransportMode;
import com.akexorcist.googledirection.model.Direction;
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

public class Destination_Route extends FragmentActivity  implements OnMapReadyCallback,LocationListener, View.OnClickListener, DirectionCallback {


    private GoogleMap Googlemap;
    private String serverKey = "AIzaSyDAmhMqwMh_htnUKxPFjCiZmVr6-eDwnvo";
    private LatLng origin;
    private LatLng destination;
    private String[] colors = {"#7fff7272", "#7f31c7c5", "#7fff8a00"};
    private LocationListener listener;
    private LocationManager manager;
    private LatLng latlng;
    private LocationManager locationManagerCt;
    private GoogleMap mMap;
    private Location locationCt;
    private HashMap<String, String> BookingContainer;
    private Button btnUpDeliv;
    private LatLng loc ;
    private String response = "";
    private LatLng currentPosition;
    private SessionManager session;
    private HashMap<String, String> user;
    private double kilo =0;
    private String Username;
    private String Vehicle_Reg;
    private Button btnUpCollection;
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
        setContentView(R.layout.activity_destination__route);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);

        findViewById(R.id.btn_request_direction).setOnClickListener(this);

        btnUpDeliv = (Button) findViewById(R.id.btn_Update_Deliv);

        // Login button click event
        btnUpDeliv.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), Activity_UpdateDelivery.class);
                startActivity(i);
            } });

        session = new SessionManager(getApplicationContext());
        user = session.getUserDetails();
        Username= user.get(SessionManager.KEY_NAME);
        Vehicle_Reg = user.get(SessionManager.KEY_VEHICLE);
    }


    @Override
    public void onMapReady(GoogleMap googleMap) {
        //this.googleMap = googleMap;
        Googlemap = googleMap;

        try {
            currentPosition = getLocation();
            request = "http://192.168.43.137:3032/Service1.svc/UpdateLocation?Username=" + Username +"&Lat="+currentPosition.latitude+"&Long="+ currentPosition.longitude ;
           System.out.println(request);
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

        Thread t = new Thread() {
            @Override
            public void run() {
                try {
                    Looper.prepare();
                    sleep(2000);
                }
                catch (Exception e) {}
                finally {
                    list1 = new ArrayList<String>();
                    list2 = new ArrayList<String>();

                    if(separated2 != null) {
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
                            System.out.println("-----------------delivery adress " + separated2[3]);
                            list2.add(separated2[3]);

                            ad2 = list2.get(0).toString();
                            System.out.println("-----------------delivery adress " + ad2);

                            try {
                                fromLocationName2 = geocoder.getFromLocationName(ad2, 1);
                            } catch (Exception e) {
                            }

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
                           if(currentPosition != null)
                           {
                               if(destination !=null)
                               {
                                   Googlemap.moveCamera(CameraUpdateFactory.newLatLng(currentPosition));
                                   Googlemap.animateCamera(CameraUpdateFactory.newLatLngZoom(currentPosition, 15));
                                   Googlemap.addMarker(new MarkerOptions().position(currentPosition).snippet("This is the Driver's location").title("Driver's current loction"));

                                   GoogleDirection.withServerKey(serverKey)
                                           .from(currentPosition)
                                           .to(destination)
                                           .transportMode(TransportMode.DRIVING)
                                           .alternativeRoute(true)
                                           .execute(Destination_Route.this);
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
        openActivity(Alternative_Routes2.class);
    }

    public void openActivity(Class<?> cs) {
        startActivity(new Intent(this, cs));
    }

    @Override
    public void onDirectionSuccess(Direction direction, String rawBody) {

        if (direction.isOK()) {
            Googlemap.addMarker(new MarkerOptions().position(origin).snippet("This is the collection location").title("Origin").icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_BLUE)));
            Googlemap.addMarker(new MarkerOptions().position(destination).snippet("This is the delivery location").title("Destination").icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_GREEN)));
            Googlemap.addMarker(new MarkerOptions().position(currentPosition).snippet("This is the Driver's location").title("Driver's current loction"));

            ArrayList<LatLng> directionPositionList = direction.getRouteList().get(0).getLegList().get(0).getDirectionPoint();
            Googlemap.addPolyline(DirectionConverter.createPolyline(this, directionPositionList, 5, Color.RED));

            float [] dist = new float[1];
            Location.distanceBetween(currentPosition.latitude ,destination.latitude ,
                    currentPosition.longitude , destination.longitude ,dist);
            kilo = dist[0] * 0.0000001;

            request = "http://192.168.43.137:3032/Service1.svc/UpdateKilometers?Vehicle_Reg = "+ Vehicle_Reg+"& Kilometers = "+kilo;
            new connection().execute(request);
        }
    }

    @Override
    public void onDirectionFailure(Throwable t) {}

    @Override
    public void onLocationChanged(Location location) {}

    @Override
    public void onProviderDisabled(String provider) {}

    @Override
    public void onProviderEnabled(String provider) {}

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
