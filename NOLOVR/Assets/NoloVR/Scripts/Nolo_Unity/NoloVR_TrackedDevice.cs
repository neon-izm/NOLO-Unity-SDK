/*************************************************************
 * 
 *  Copyright(c) 2017 Lyrobotix.Co.Ltd.All rights reserved.
 *  NoloVR_TrackedDevice.cs
 *   
*************************************************************/

using UnityEngine;

public class NoloVR_TrackedDevice : MonoBehaviour {

    public NoloDeviceType deviceType;
    private GameObject vrCamera;
    private Vector3 centralPointVector = new Vector3(0, 0.09f, 0.06f);
    void Start()
    {
        vrCamera = NoloVR_Manager.GetInstance().VRCamera;
    }
	void Update () {
        UpdatePose();
    }

    void UpdatePose()
    {
        var pose = NoloVR_Controller.GetDevice(deviceType).GetPose();
        if (deviceType == NoloDeviceType.Hmd)
        {
            if (vrCamera == null)
            {
                Debug.LogError("Not find your vr camera");
                transform.localPosition = pose.pos;
            }
            transform.localPosition = pose.pos - vrCamera.transform.localPosition - vrCamera.transform.localRotation * centralPointVector;
        }
        else
        {
            transform.localPosition = pose.pos;
            transform.localRotation = pose.rot;
        }
    }
}
