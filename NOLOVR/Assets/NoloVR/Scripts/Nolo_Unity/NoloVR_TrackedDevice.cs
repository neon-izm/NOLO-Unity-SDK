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
    void Start()
    {
        vrCamera = NoloVR_Manager.GetInstance().VRCamera;
    }
	void Update () {
        //更新位置
        UpdatePose();
    }

    private float camerayaw;
    private float noloyaw;
    private float resetyaw;
    private float prersetyaw;
    private float resultyaw;
    private float angleAdjustmentRate = 1f / 120f;
    private Vector3 centralPointVector = new Vector3(0, 0.09f, 0.06f);

    void UpdatePose()
    {
        var pose = NoloVR_Controller.GetDevice(deviceType).GetPose();
        if (deviceType == NoloDeviceType.Hmd)
        {
            if (vrCamera == null)
            {
                Debug.LogError("Not find your vr camera");
                transform.localPosition = pose.pos;
                return;
            }
            //Correct the camera yaw
            noloyaw = pose.rot.eulerAngles.y;
            resetyaw = noloyaw - camerayaw > 0 ? noloyaw - camerayaw : noloyaw - camerayaw + 360;
            prersetyaw = transform.localRotation.eulerAngles.y;
            resultyaw = resetyaw - prersetyaw;
            if (resultyaw > -360 && resultyaw < -340)
            {
                transform.localRotation = Quaternion.Euler(0, prersetyaw + angleAdjustmentRate, 0);
            }
            else if (resultyaw > 0 && resultyaw < 20)
            {
                transform.localRotation = Quaternion.Euler(0, prersetyaw + angleAdjustmentRate, 0);
            }
            else if (resultyaw > -20 && resultyaw < 0)
            {
                transform.localRotation = Quaternion.Euler(0, prersetyaw - angleAdjustmentRate, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, resetyaw, 0);
            }
            camerayaw = vrCamera.transform.localRotation.eulerAngles.y;
            //Correct the camera position
            var cameraLoaclPosition = transform.localRotation * vrCamera.transform.localPosition;
            var noloCentralPointVector = transform.localRotation * centralPointVector;
            transform.localPosition = pose.pos - cameraLoaclPosition - noloCentralPointVector;

           

        }
        else
        {
            transform.localPosition = pose.pos;
            transform.localRotation = pose.rot;
        }
    }
}
