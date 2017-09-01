# NOLO VR SDK For Unity
Develop moblie VR/AR with Unity.  

For first time users, see the [Get Started](./Docs/en_us/GetStarted.md)([快速入门](./Docs/zh_cn/快速入门.md)).  

APP can run in any Android device,include mobile phone or all-in-one device.  

For example:
- [Gear VR](https://github.com/NOLOVR/NOLO-Unity-SDK/blob/master/Docs/en_us/GetStarted.md#build-gear-vr-example)
- [Cardboard](https://github.com/NOLOVR/NOLO-Unity-SDK/blob/master/Docs/en_us/GetStarted.md#build-cardboard-example)
- [Other](https://github.com/NOLOVR/NOLO-Unity-SDK/blob/master/Docs/en_us/GetStarted.md#other-vr-sdk)

If you have problems,Check [FAQ](https://github.com/NOLOVR/NOLO-Unity-SDK/issues).  
## For developer
* It is important to add the double click system button to reset camera's yaw.  
such as:  
Gear VR:InputTracking.Recenter();  
Cardboard:GvrViewer.Instance.Recenter();
* about application icon  
We would like to be able to add an icon on the app icon,Indicates support for nolo devices,Material has been in unitypackage.


## NOLOVR SDK Version 1.1.6

* 1.Both automatic and manual to Connect to nolo devices:     
    automatic:NoloVR_Manager->automaticConnection = true;
    manual:NOLO_Events.Send(NOLO_Events.EventsType.ConnectNoloDevice);      
* 2.Customize the hot-key for 180 degree turn around function. You can choose different hotkeys for the function or disable it.       
* 3.Remove the boxcollider on the prefabs.
 
Documentation for the API is available on the [Wiki](https://github.com/NOLOVR/NOLO-Unity-SDK/wiki).


