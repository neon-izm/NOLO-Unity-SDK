/*************************************************************
 * 
 *  Copyright(c) 2017 Lyrobotix.Co.Ltd.All rights reserved.
 *  NoloVR_Utils.cs
 *   
*************************************************************/
using UnityEngine;
using System.Collections;

public struct Nolo_Transform
{
    public Vector3 pos;
    public Quaternion rot;
    public Nolo_Transform(NoloVR_Plugins.Nolo_Pose pose)
    {
        this.pos.x = pose.pos.x;
        this.pos.y = pose.pos.y;
        this.pos.z = pose.pos.z;

        this.rot.w = pose.rot.w;
        this.rot.x = pose.rot.x;
        this.rot.y = pose.rot.y;
        this.rot.z = pose.rot.z;
    }
    public Nolo_Transform(Vector3 pos,Quaternion rot)
    {
        this.pos = pos;
        this.rot = rot;
    }
    public static Nolo_Transform identity
    {
       get { return new Nolo_Transform(Vector3.zero, Quaternion.identity); }
    }
}

public class NOLO_Events
{
    public enum EventsType
    {
        TrackingOutofRange,
        TrackingInRange,
        TurnAround,
        ConnectNoloDevice
    }
    public delegate void Handler(params object[] args);

    public static void Listen(EventsType eventMessage, Handler action)
    {
        var actions = listeners[eventMessage] as Handler;
        if (actions != null)
        {
            listeners[eventMessage] = actions + action;
        }
        else
        {
            listeners[eventMessage] = action;
        }
    }

    public static void Remove(EventsType eventMessage, Handler action)
    {
        var actions = listeners[eventMessage] as Handler;
        if (actions != null)
        {
            listeners[eventMessage] = actions - action;
        }
    }

    public static void Send(EventsType eventMessage, params object[] args)
    {
        var actions = listeners[eventMessage] as Handler;
        if (actions != null)
        {
            actions(args);
        }
    }

    private static Hashtable listeners = new Hashtable();

}


