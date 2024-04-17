using System;
using System.Collections;
using System.Text;
using WebSocketSharp;

namespace SPANDAN_SDK_POC
{
    internal class CommunicationHelper
    {
        static WebSocket ws = new WebSocket("ws://localhost:8080");
        private static IOnDataReceiver onDataReceiver;
        private static  ArrayList leadPoints = new ArrayList();

        public static void RegisterOnDataReceiver(IOnDataReceiver receiver)
        {
            onDataReceiver = receiver;
        }
        public static async Task sendCommand(String command)
        {

            if (command.Contains("ecgPosition-"))
                leadPoints.Clear();
            ws.Send(command);

        }
        public static async Task startClient(string maskterKey)
        {
            
            bool messageSent = false;
            ws.OnMessage += (sender, e) =>
            {
                if (e.Data.Contains("Completed"))
                {
                    onDataReceiver.onPositionRecordingComplete(e.Data,leadPoints);
                }
                if (e.Data.Contains("State"))
                {
                    onDataReceiver.onDeviceConnectionStateChanged("DEVICE "+e.Data.Split(":")[1]);
                }
                if (e.Data.Contains("Verified"))
                {
                    onDataReceiver.onDeviceConnectionStateChanged("Device Id "+e.Data.Split(":")[1]);
                }
                if (e.Data.Contains("Points"))
                {
                    leadPoints.Add(e.Data.Split(":")[1]);
                    onDataReceiver.onReceivedData(e.Data.Split(":")[1]);
                }
                if (e.Data.Contains("Created"))
                {
                    onDataReceiver.onReceivedData(e.Data);
                }
                if (e.Data.Contains("Authenticated"))
                {
                    onDataReceiver.onSDKConnectionStateChanged(e.Data);
                }
                if (e.Data.Contains("Error"))
                {
                    onDataReceiver.onReceiveError(e.Data.Split(":")[1]);
                }

            };

            // Continuously try to connect
            while (true)
            {
                try
                {
                    Console.WriteLine("Attempting to connect...");
                    ws.Connect();
                    

                    if (ws.ReadyState == WebSocketState.Open)
                    {
                    

                        if (!messageSent)
                        {
                           // onDataReceiver.onDeviceConnectionStateChanged("CONNECTED");
                            ws.Send("connect-"+maskterKey);
                           messageSent = true;
                            Console.WriteLine("Connected!");
                            
                        }

       
                    }
                    else
                    {
                        Console.WriteLine("Connection failed.");
                       
                        onDataReceiver.onSDKConnectionStateChanged("DISCONNECTED");

                        messageSent = false;
                    }
                }
                catch (WebSocketSharp.WebSocketException)
                {
                    Console.WriteLine("Connection failed. Retrying in 5 seconds...");
                  
                    onDataReceiver.onSDKConnectionStateChanged("DISCONNECTED");
                    messageSent = false;
                   
                }
                catch (ObjectDisposedException ex)
                {
                    // Handle the ObjectDisposedException
                    Console.WriteLine($"ObjectDisposedException: {ex.Message}");
       
                    onDataReceiver.onSDKConnectionStateChanged("DISCONNECTED");
                    messageSent = false;
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                   
                    onDataReceiver.onSDKConnectionStateChanged("DISCONNECTED");
                    messageSent = false;
                    
                }
            }
        }
    }

  
}
