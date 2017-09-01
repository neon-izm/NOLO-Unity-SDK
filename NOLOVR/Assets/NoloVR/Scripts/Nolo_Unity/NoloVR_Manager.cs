/*************************************************************
 * 
 *  Copyright(c) 2017 Lyrobotix.Co.Ltd.All rights reserved.
 *  NoloVR_Manager.cs
 *   
*************************************************************/

using UnityEngine;
using UnityEngine.VR;

public class NoloVR_Manager : MonoBehaviour
{
    public enum TurnAroundButtonType
    {
        Menu,
        Touchpad,
        Grip,
        Null
    }
    [Tooltip("Camera's rotation should be changed when the app running")]
    public GameObject VRCamera;
    [Tooltip("App will automatic connected NOLO devices")]
    public bool automaticConnection = true;
    [Tooltip("Double click turnaround button")]
    public TurnAroundButtonType turnAroundButtonType;
    private NoloButtonID buttontype;

    [HideInInspector]
    public NoloVR_TrackedDevice[] objects;


    private static NoloVR_Manager instance;
    private NoloVR_Manager() { }
    public static NoloVR_Manager GetInstance()
    {
        if (instance == null)
        {
            instance = new NoloVR_Manager();
        }
        return instance;
    }


    private int spacingFrame = 200;

    void Awake()
    {
        instance = this;
        objects = GameObject.FindObjectsOfType<NoloVR_TrackedDevice>();
        GameObject androidCallBack = new GameObject("USB Host Peripherals");
        androidCallBack.AddComponent<NoloVR_AndroidCallBack>();
        switch (turnAroundButtonType)
        {
            case TurnAroundButtonType.Menu:
                buttontype = NoloButtonID.Menu;
                break;
            case TurnAroundButtonType.Touchpad:
                buttontype = NoloButtonID.TouchPad;
                break;
            case TurnAroundButtonType.Grip:
                buttontype = NoloButtonID.Grip;
                break;
            case TurnAroundButtonType.Null:
                break;
            default:
                break;
        }
        NoloVR_Controller.Listen();
        
    }
    void OnEnable()
    {
        NOLO_Events.Listen(NOLO_Events.EventsType.ConnectNoloDevice, ConnectionNOLO);
    }
    void OnDisable()
    {
        NOLO_Events.Remove(NOLO_Events.EventsType.ConnectNoloDevice, ConnectionNOLO);
    }
    void Update ()
    {
        //automatic connect the usb device
        if (automaticConnection)
        {
            if (NoloVR_Playform.InitPlayform().GetPlayformError() != NoloError.None)
            {
                if (spacingFrame < 200)
                {
                    spacingFrame++;
                }
                else
                {
                    ConnectionNOLO();
                    spacingFrame = 0;
                }
            }
         
        }
        if (turnAroundButtonType!= TurnAroundButtonType.Null)
        {
            TurnAroundEventsMonitor();
        }
        Recenter();
        
    }

    //turn around about
    private int leftcontrollerTurn_PreFrame = -1;
    private int rightcontrollerTurn_PreFrame = -1;
    private int turnAroundSpacingFrame = 20;
    void TurnAroundEventsMonitor()
    {
        //leftcontroller double click system button
        if (NoloVR_Controller.GetDevice(NoloDeviceType.LeftController).GetNoloButtonUp(buttontype))
        {
            if (Time.frameCount - leftcontrollerTurn_PreFrame <= turnAroundSpacingFrame)
            {
                NOLO_Events.Send(NOLO_Events.EventsType.TurnAround);
                leftcontrollerTurn_PreFrame = -1;
            }
            else
            {
                leftcontrollerTurn_PreFrame = Time.frameCount;
            }
        }
        //rightcontroller double click system button
        if (NoloVR_Controller.GetDevice(NoloDeviceType.RightController).GetNoloButtonUp(buttontype))
        {
            if (Time.frameCount - rightcontrollerTurn_PreFrame <= turnAroundSpacingFrame)
            {
                NOLO_Events.Send(NOLO_Events.EventsType.TurnAround);
                rightcontrollerTurn_PreFrame = -1;
            }
            else
            {
                rightcontrollerTurn_PreFrame = Time.frameCount;
            }
        }
    }
    //recenter about
    private int leftcontrollerRecenter_PreFrame = -1;
    private int rightcontrollerRecenter_PreFrame = -1;
    private int recenterSpacingFrame = 20;
    void Recenter()
    {
        //leftcontroller double click system button
        if (NoloVR_Controller.GetDevice(NoloDeviceType.LeftController).GetNoloButtonUp(NoloButtonID.System))
        {
            if (Time.frameCount - leftcontrollerRecenter_PreFrame <= recenterSpacingFrame)
            {
                InputTracking.Recenter();
                leftcontrollerRecenter_PreFrame = -1;
            }
            else
            {
                leftcontrollerRecenter_PreFrame = Time.frameCount;
            }
        }
        //rightcontroller double click system button
        if (NoloVR_Controller.GetDevice(NoloDeviceType.RightController).GetNoloButtonUp(NoloButtonID.System))
        {
            if (Time.frameCount - rightcontrollerRecenter_PreFrame <= recenterSpacingFrame)
            {
                InputTracking.Recenter();
                rightcontrollerRecenter_PreFrame = -1;
            }
            else
            {
                rightcontrollerRecenter_PreFrame = Time.frameCount;
            }
        }
    }

    void ConnectionNOLO(params object[] args)
    {
        NoloVR_Playform.InitPlayform().ConnectDevice();
    }

    void OnApplicationQuit()
    {
        //close connect from device
        Debug.Log("Nolo debug:Application quit");
        NoloVR_Playform.InitPlayform().DisconnectDevice();
        NoloVR_Controller.Remove();
    }

}
