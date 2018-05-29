package coding_crusade.intellifleetmobile;

import android.os.AsyncTask;

/**
 * Created by ObesT on 2016-08-29.
 */
public class PostTask extends AsyncTask<String, Integer, String> {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
            }

            @Override
            protected String doInBackground(String... params) {
                String url=params[0];

                for (int i = 0; i <= 100; i += 5) {
                    try {
                        Thread.sleep(50);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    publishProgress(i);
                }
                return "All Done!";
            }

            @Override
            protected void onProgressUpdate(Integer... values) {
                super.onProgressUpdate(values);
            }

            @Override
            protected void onPostExecute(String result) {
                super.onPostExecute(result);
            }
}
