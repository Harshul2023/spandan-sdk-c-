using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPANDAN_SDK_POC
{

    public partial class Form1 : Form, IOnDataReceiver
    {

        public Form1()
        {
            InitializeComponent();
            SpandanSdk.RegisterOnDataReceiver(this);
            Task.Run(() => SpandanSdk.startClient("4u838u43u439u3")); // Run startClient asynchronously
        }

        public void onDeviceConnectionStateChanged(string data)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = data));



        }

        public void onDeviceTypeChange(string data)
        {
            throw new NotImplementedException();
        }

        public void onDeviceVerified(string data)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = data));

        }

        public void onElapsedTimeChanged(string data)
        {
            throw new NotImplementedException();
        }

        public void onPositionRecordingComplete(string points, System.Collections.ArrayList leadPoints)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = points + " count ---->  " + leadPoints.Count));

            progressBar1.Invoke((MethodInvoker)(() =>
            {
                progressBar1.Value = 100;
            }));

        }

        public void onReceivedData(string points)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = points));
        }

        public void onReceiveError(string points)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = points));
        }

        public  void onReportError(string error)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = error));
        }

        public void onReportGeneration(string url)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = url));
        }

        public void onSDKConnectionStateChanged(string points)
        {
            checkBox1.Invoke((MethodInvoker)(() =>
            {
                if (points == "DISCONNECTED")
                {
                    checkBox1.Text = "NOT Authenticated";
                    label3.Invoke((MethodInvoker)(() => label3.Text = "SDK DISCONNECTED"));
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Text = "Authenticated";
                    label3.Invoke((MethodInvoker)(() => label3.Text = points));
                    checkBox1.Checked = true;
                }
            }));
        }

        public void onTestStarted(string data)
        {
            label3.Invoke((MethodInvoker)(() => label3.Text = data));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SpandanSdk.sendCommand("createTest-" + EcgTestType.LEAD_TWO.ToString());
            // Handle button click event
        }

        private void button2_Click(object sender, EventArgs e)

        {
            progressBar1.Value = 0;
            SpandanSdk.sendCommand("ecgPosition-" + EcgPosition.LEAD_2.ToString());
            // Handle button click event
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JObject jsonObject = new JObject();
            jsonObject.Add("age", "34");
            jsonObject.Add("first_name", "Harshul");
            jsonObject.Add("gender", "Male");
            jsonObject.Add("generateReport", true);
            jsonObject.Add("height", "147");
            jsonObject.Add("last_name", "Mittal");
            jsonObject.Add("report_type", EcgTestType.LEAD_TWO.ToString());
            jsonObject.Add("weight", "70");

            // Convert the JSON object to a string
            string jsonString = jsonObject.ToString();


            SpandanSdk.sendCommand("generate report-"+jsonString);
        }

        
    }
}
