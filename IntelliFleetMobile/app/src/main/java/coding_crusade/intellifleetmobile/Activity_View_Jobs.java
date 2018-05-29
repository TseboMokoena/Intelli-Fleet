package coding_crusade.intellifleetmobile;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.webkit.WebView;

import java.util.HashMap;

public class Activity_View_Jobs extends AppCompatActivity {
    private ProgressDialog pd;
    private SessionManager session;
    private HashMap<String, String> user;

    private String Table;
    private String html;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_jobs);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LOCKED);

        // Session class instance
        session = new SessionManager(getApplicationContext());

        // get user data from session
        user = session.getUserDetails();

        Table = user.get(SessionManager.KEY_DELIVERIES);

/*

        pd = ProgressDialog.show(Activity_View_Jobs.this, "Please Wait...", "Loading jobs...", false, true);
        pd.setCanceledOnTouchOutside(false);
        Thread t = new Thread() {
            @Override
            public void run() {
                try {


                    sleep(3000);  //Delay of 10 seconds
                } catch (Exception e) {

                } finally {

                    pd.dismiss();
                    // Table = response;

                    //   System.out.println("Response:" + response);


                }
            }
        };
        t.start();*/

        html = "<html lang=\"en\">\n" +
                "<head>\n" +
                "    <meta charset=\"utf-8\" />\n" +
                "    <title><%: Page.Title %> - Intelli-Fleet</title>\n" +
                "  \n" +
                "     <!-- Bootstrap -->\n" +
                "        <link href=\"bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\">\n" +
                "        <link href=\"css/waves.min.css\" type=\"text/css\" rel=\"stylesheet\"> \n" +
                "        <link href=\"css/menu-light.css\" type=\"text/css\" rel=\"stylesheet\">\n" +
                "        <link href=\"css/style.css\" type=\"text/css\" rel=\"stylesheet\">\n" +
                "        <link href=\"font-awesome/css/font-awesome.min.css\" rel=\"stylesheet\"></head>" +
                "<body> <h1>Pending deliveries<small></small></h1>" +
                "<div class=\"table-responsive\">" +
                Table +
                " </table></div></body></html>";

        WebView webview;
        webview = new WebView(Activity_View_Jobs.this);
        webview.loadDataWithBaseURL("file:///android_asset/", html, "text/html", "UTF-8", null);
        setContentView(webview);
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        Intent i = new Intent(getApplicationContext(), Activity_PendingDeliveries.class);
        startActivity(i);
        finish();
    }
}
