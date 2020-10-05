using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class StartingPointController : MonoBehaviour
{
    public Color red;
    public Color amber;
    public Color green;
    public Session session;

    // reference to the material we want to change the color of.
    Material mat;
    // Start is called before the first frame update
    void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    IEnumerator Countdown()
    {
        float timePeriod = session.settings.GetFloat("startpoint_period");
        yield return new WaitForSeconds(timePeriod);
        mat.color = green;
        session.BeginNextTrial();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cursor" & !session.InTrial)
        {
            mat.color = amber;
            StartCoroutine(Countdown());
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cursor")
        {
            StopAllCoroutines();
            mat.color = red;
        }
    }
}
