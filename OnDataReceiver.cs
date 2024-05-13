using System;
public interface IOnDataReceiver
{
   
    void onDeviceConnectionStateChanged(string data);
    void onDeviceVerified(string data);
    void onDeviceTypeChange(string data);
 
    
    void onSDKConnectionStateChanged(string state);
    void onElapsedTimeChanged(string data);
    void onTestStarted(string data);
    void onReceivedData(string data);
    void onPositionRecordingComplete(string points, System.Collections.ArrayList leadPoints);
    void onReceiveError(string error);
}
enum EcgTestType
{
    TWELVE_LEAD,
    LEAD_TWO,
    HRV,
    HYPERKALEMIA,
    LIVE_MONITOR
}
enum EcgPosition

{
    V1,
    V2,
    V3,
    V4,
    V5,
    V6,
    LEAD_2,
    LEAD_1
}