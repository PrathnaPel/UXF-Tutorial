using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TaskAreaController : MonoBehaviour
{
    public Session session;
    public Transform startPoint;
    // Start is called before the first frame update

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cursor" & session.InTrial)
        {
            Vector3 cursorPos = other.transform.position;
            cursorPos.y = 0;
            Vector3 targetDir = Vector3.forward;

            float angle = Vector3.SignedAngle(targetDir, cursorPos, Vector3.up);
            Debug.Log(angle);

            session.CurrentTrial.result["angle"] = angle;

            float threshold = 4.0f;
            bool hit = Math.Abs(angle) < threshold;
            session.CurrentTrial.result["outcome"] = hit ? "hit" : "miss";

            session.EndCurrentTrial();
        }
    }
}
