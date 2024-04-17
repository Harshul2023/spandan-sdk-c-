using System;
public interface IOnDataReceiver
{
   
    void onDeviceConnectionStateChanged(string data);
    void onDeviceVerified(string data);
    void onDeviceTypeChange(string data);
    void onTestStarted(string data);
    void onElapsedTimeChanged(string data);
    void onReceivedData(string points);
    void onPositionRecordingComplete(string points, System.Collections.ArrayList leadPoints);
    void onSDKConnectionStateChanged(string points);
    void onReceiveError(string points);
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