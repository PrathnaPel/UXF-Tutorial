using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class VisuoMotorRotation : MonoBehaviour
{
    public Session session;
    public Transform hiddenCursor;
    public Transform startPoint;

    float vmrAngle = 0f;
    MeshRenderer cursorMR;
    bool clamped = false;

    void Awake()
    {
        cursorMR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!session.hasInitialised | !session.InTrial)
        {
            transform.position = hiddenCursor.position;
            return;
        }
        // update the position of this object
        if (clamped)
        {
            float dist = (hiddenCursor.position - startPoint.position).magnitude;
            Vector3 newPos = startPoint.position + Vector3.forward * dist;
            newPos.y = transform.position.y; // lock to 2D
            transform.position = newPos;
        }
        else
        {
            transform.position = hiddenCursor.position;
        }
        transform.RotateAround(startPoint.position, Vector3.up, vmrAngle);
    }

    // assign this function to run On Trial Begin
    public void UpdateSettings(Trial trial)
    {
        // use settings.Get*() to access settings (independent variables)
        vmrAngle = session.CurrentTrial.settings.GetFloat("vmr_angle");
        clamped = session.CurrentTrial.settings.GetBool("clamped_error");
        cursorMR.enabled = session.CurrentTrial.settings.GetBool("online_feedback");
    }
}
