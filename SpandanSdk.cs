﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using WebSocketSharp;

namespace SPANDAN_SDK_POC
{
    internal class SpandanSdk
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
        public static Task startClient(string maskterKey)
        {
            Task.Run(() => startServer());
        

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
                if (e.Data.Contains("Connected:Server"))
                {
                    onDataReceiver.onSDKConnectionStateChanged(e.Data);
                }
                if (e.Data.Contains("Report:"))
                {
                    onDataReceiver.onReceivedData(e.Data);
                }
                if (e.Data.Contains("Report Error:"))
                {
                    onDataReceiver.onReportError(e.Data);
                }
                
            };

            ws.OnOpen += (sender, e) => ws.Send("Hi, there!");

            // Continuously try to connect
            while (true)
            {
                try
                {
                    Console.WriteLine("Attempting to connect...");
                    //ws.ConnectAsync();
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
                 
                    Console.WriteLine($"ObjectDisposedException: {ex.Message}");
       
                    onDataReceiver.onSDKConnectionStateChanged("DISCONNECTED");
                    messageSent = false;
                }
                catch (Exception ex)
                {
                  
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    ws.Close();
                  
                    onDataReceiver.onSDKConnectionStateChanged("Please Wait....");
                    messageSent = false;
                    
                }
              
            }
        }

        private static void startServer()
        {

            string strCmdText = "java -jar C:\\Users\\harsh\\IdeaProjects\\sericomm\\build\\libs\\sericomm-1.0-SNAPSHOT-all.jar";
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + strCmdText;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // Read the output (if needed)
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);


        }
    }

  
}
