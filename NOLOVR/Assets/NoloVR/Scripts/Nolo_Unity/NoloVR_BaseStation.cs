using UnityEngine;
using System.Collections;

public class NoloVR_BaseStation : MonoBehaviour {
    private Vector3 prePos = Vector3.zero;
    void Update()
    {
        if (NoloVR_Playform.InitPlayform().GetPlayformError() != NoloError.None)
        {
            return;
        }

        transform.localPosition = new Vector3(0, -NoloVR_Plugins.GetHmdInitPosition().y, 0);

        for (int i = 0; i < NoloVR_Manager.GetInstance().objects.Length; i++)
        {
            if (Mathf.Abs (NoloVR_Manager.GetInstance().objects[i].transform.localPosition.x) > Mathf.Abs(NoloVR_Manager.GetInstance().objects[i].transform.localPosition.z)||
                Mathf.Abs(NoloVR_Manager.GetInstance().objects[i].transform.localPosition.y- transform.position.y) > Mathf.Abs(NoloVR_Manager.GetInstance().objects[i].transform.localPosition.z)+0.1f)
            {
                NOLO_Events.Send(NOLO_Events.EventsType.TrackingOutofRange);
                break;
            }
            else
            {
                NOLO_Events.Send(NOLO_Events.EventsType.TrackingInRange);
            }
        }

    }
}
