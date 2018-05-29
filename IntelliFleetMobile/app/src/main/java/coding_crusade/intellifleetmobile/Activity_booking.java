package coding_crusade.intellifleetmobile;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.RadioButton;
import android.widget.TimePicker;
import android.widget.Toast;


public class Activity_booking extends AppCompatActivity {

    private String Requirement = "";
    private String Package_Type = "";
    private String DeliveredDate = "";
    private String Delivery_stat ="";
    private  String User_Name = "";

    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;
    private Intent intent;

    View view;
    String Delivery_DateNTime;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_booking);

        //getting the reference to the button
        Button MakeBooking = (Button)findViewById(R.id.btnMakeBooking);
        intent = new Intent(this, Activity_PackageStat.class);

           MakeBooking.setOnClickListener(
                new ImageButton.OnClickListener()
                {
                    public void onClick(View v)
                    {
                        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                switch (which){
                                    case DialogInterface.BUTTON_POSITIVE:
                                        EditText package_Type = (EditText)findViewById(R.id.txtType);
                                        EditText package_Weight = (EditText)findViewById(R.id.txtWeight);
                                        EditText package_Length = (EditText)findViewById(R.id.txtLength);
                                        EditText package_Breath = (EditText)findViewById(R.id.txtWidth);
                                        EditText package_Height = (EditText)findViewById(R.id.txtHeight);
                                        EditText item_Quantity = (EditText)findViewById(R.id.txtQuantity);
                                        DatePicker delivery_Date = (DatePicker)findViewById(R.id.datePicker);
                                        TimePicker deliveryTime = (TimePicker)findViewById(R.id.timePicker);

                                        day = delivery_Date.getDayOfMonth();
                                        month = delivery_Date.getMonth();
                                        year = delivery_Date.getYear();
                                        hour = deliveryTime.getCurrentHour();
                                        minute = deliveryTime.getCurrentMinute();

                                 /*       User_Name = user.get(SessionManager.KEY_NAME);
                                        String Adress1 =  adress1.getText().toString();
                                        String Adress2 = adress2.getText().toString();
                                        String Package_Type = "type";
                                        double Package_Weight = Double.parseDouble(package_Weight.getText().toString());
                                        double Package_Length =Double.parseDouble(package_Length.getText().toString());
                                        double Package_Breath = Double.parseDouble(package_Breath.getText().toString());
                                        double Package_Height = Double.parseDouble(package_Height.getText().toString());
                                        int Item_Quantity = Integer.parseInt(item_Quantity.getText().toString());
                                        Delivery_DateNTime = year + "-" + month + "-" + day + "%20" + hour + ":" + minute;
                                        String Requirement = "None";
                                        String  Delivery_stat ="Pending";
*/


//                                        Log.v("variables","User_Name=" + User_Name + " adress1=" + adress1.getText().toString()
//                                                + " adress2=" + adress2.getText().toString() + " type=" + Package_Type
//                                                + " package_Weight=" + Double.parseDouble(package_Weight.getText().toString())
//                                                + " package_Length=" + Double.parseDouble(package_Length.getText().toString())
//                                                + " package_Breath=" +  Double.parseDouble(package_Breath.getText().toString())
//                                                + " package_Height=" + Double.parseDouble(package_Height.getText().toString())
//                                                + " item_Quantity=" +  Integer.parseInt(item_Quantity.getText().toString())
//                                                + " Delivery_DateNTime=" + Delivery_DateNTime
//                                                + " Requirement=" + Requirement + " Delivery_stat=" + Delivery_stat
//                                                + " DeliveredDate=" + DeliveredDate);


                                        String User_Name = "Client1";
                                        String Adress1 = "ad1";
                                        String Adress2 = "ad2";
                                        String Package_Type = "type";
                                        double Package_Weight = 1.5;
                                        double Package_Length =1.6;
                                        double Package_Breath = 1.8;
                                        double Package_Height = 1.9;
                                        int Item_Quantity = 2;
                                        String Delivery_DateNTime = "2016-7-8%2015:14";

                                        String Requirement = "None";
                                        String  Delivery_stat ="In Progress";

                                        Log.v("variables","User_Name=" + User_Name + " adress1=" + Adress1
                                                + " adress2=" + Adress2 + " type=" + Package_Type
                                                + " package_Weight=" + Package_Weight
                                                + " package_Length=" + Package_Length
                                                + " package_Breath=" + Package_Breath
                                                + " package_Height=" + Package_Height
                                                + " item_Quantity=" +  Item_Quantity
                                                + " Delivery_DateNTime=" + Delivery_DateNTime
                                                + " Requirement=" + Requirement + " Delivery_stat=" + Delivery_stat
                                                + " DeliveredDate=" + DeliveredDate);


                                    /*    CallingWCF.MakeBooking( User_Name,  Adress1,  Adress2,  Package_Type,
                                                Package_Weight,  Package_Length,
                                                Package_Breath,  Package_Height,  Item_Quantity,
                                                Delivery_DateNTime,  Requirement, Delivery_stat);*/

                                       // alert.showAlertDialog(Activity_PackageStat.this, "Success", "Booking made successfully", true);
                                         Toast.makeText(getApplicationContext(), "Booking Successful", Toast.LENGTH_LONG).show();
                                        startActivity(intent);
                                        break;


                                    case DialogInterface.BUTTON_NEGATIVE:
                                        //No button clicked
                                        break;
                                }
                            }
                        };

                        AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                        builder.setMessage("Are you sure you want to make a booking?").setPositiveButton("Yes", dialogClickListener)
                                .setNegativeButton("No", dialogClickListener).show();


                    }
                }
        );

    }

    public void onRadioButtonClicked(View view) {
        // Is the button now checked?
        boolean checked = ((RadioButton) view).isChecked();

        // Check which radio button was clicked
        switch(view.getId()) {
            case R.id.radio_PerishableGoods:
                if (checked)
                    Package_Type = "Perishable Goods";
                    break;
            case R.id.radio_Animals:
                if (checked)
                    Package_Type = "Animals";
                    break;
            case R.id.radio_Equipment:
                if (checked)
                    Package_Type = "Equipment";
                    break;
            case R.id.radio_Liquids:
                if (checked)
                    Package_Type = "Liquids";
                    break;
            case R.id.radio_Assets:
                if (checked)
                    Package_Type = "Assets";
                    break;
            case R.id.radio_Other:
                if(checked)

                break;

            case R.id.opencannopy:
                if (checked)
                    Requirement = "Open Cannopy";
                    break;
            case R.id.refrigiration:
                if (checked)
                    Requirement = "Refrigiration";
                break;

            case R.id.heater:
                if (checked)
                    Requirement = "Heater";
                    break;
             case R.id.none:
                if (checked)
                    Requirement = "None";
        break;
    }
    }









































/*
        MakeBooking.setOnClickListener(
                new ImageButton.OnClickListener() {
                    public void onClick(View v) {
                        // result.setText(CallWCF.GetString("test"));

                        //   CallWCF.GetString("test");

                        String User_Name = "Client1";
                        String Adress1 = "ad1";
                        String Adress2 = "ad2";
                        String Package_Type = "type";
                        double Package_Weight = 1.5;
                        double Package_Length =1.6;
                        double Package_Breath = 1.8;
                        double Package_Height = 1.9;
                        int Item_Quantity = 2;
                        String Delivery_DateNTime = "2016-7-8%2015:14";
                        String Requirement = "None";
                        String  Delivery_stat ="Pending";


                        System.out.println("From call" +User_Name + "-" + Adress1 + "-" + Adress2 + "-" + Package_Type +"-"+Package_Weight
                                + "-" + Package_Length + "-" + Package_Breath +"-" +Package_Height +"-"+Item_Quantity+ "-" + Delivery_DateNTime +
                                "-" +Requirement +"-"+ Delivery_stat);

        */
/*        String x = CallWCF.MakeBooking(User_Name,  Adress1,  Adress2,  Package_Type,
                 Package_Weight,Package_Length,Package_Breath,Package_Height,  Item_Quantity,
                 Delivery_DateNTime,  Requirement, Delivery_stat);

                System.out.println(x);
*//*

                        String name="Ncedo";
                        String Surname="Lushozi";
                        String Username="Client3";
                        String Email="t@t.com";
                        String Password="12345";
                        String ConfirmPassword="12345";
                        int usertype = 1;
                        int booking_id = 3068;
                        int booking_id2 = 1068;
                        String Active = "True";



                        String Exi = CallingWCF.CheckExistinG( name,  Surname,  Username);
                        System.out.println("Type:"+Exi);

                        String Exin = CallingWCF.CheckExistingUName( name,  Surname,  Username);
                        System.out.println("Type:"+Exin);

                        String reg = CallingWCF.Registration( name,  Surname,  Username,  Email,  Password,  ConfirmPassword, usertype,  Active);
                        System.out.println("Type:"+reg);

                        String T = CallingWCF.UserType(Username , Password);
                        System.out.println("Type:"+T);

                        String U =  CallingWCF.GetUsername(Username, Password);
                        System.out.println("Username:"+U);

//                CallWCF. ViewClientOrderS( Username);
//                CallWCF.ViewStatement( Username);
//                CallWCF.ViewPending();

                        //String upp = CallWCF.UpdateCollection(booking_id);
                        //System.out.println(upp);

                        // String up = CallWCF. UpdateDelivery(booking_id2);
                        // System.out.println(up);


                    }
                });
*/
}
