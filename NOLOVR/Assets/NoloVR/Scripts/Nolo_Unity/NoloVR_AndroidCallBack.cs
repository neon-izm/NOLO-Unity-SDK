/*************************************************************
 * 
 *  Copyright(c) 2017 Lyrobotix.Co.Ltd.All rights reserved.
 *  NoloVR_AndroidCallBack.cs
 *   
*************************************************************/

using UnityEngine;

public class NoloVR_AndroidCallBack : MonoBehaviour {
    /// <summary>
    /// Android USB connect or dicconnect callback message
    /// </summary>
    /// <param name="msg">"usb 设备断开":usb device been pulled out callback,"usb 设备接入":usb device plug in phone callback</param>
    public void usbDeviceState(string msg) {
        switch (msg)
        {
            case "usb 设备断开":
                NoloVR_Playform.InitPlayform().DisConnectedCallBack();
                break;
            case "usb 设备接入":
                NoloVR_Playform.InitPlayform().ReconnectDeviceCallBack();
                break;
            default:
                break;
        }
    }
}
