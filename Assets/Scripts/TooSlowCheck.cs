using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TooSlowCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip failsound;
    public Session session;

    public void BeginCountdown()
    {
        StartCoroutine(Countdown());
    }
    public void StopCountdown()
    {
        StopAllCoroutines();
    }
    IEnumerator Countdown()
    {
        float timeoutPeriod = session.CurrentTrial.settings.GetFloat("timeout_period");
        yield return new WaitForSeconds(timeoutPeriod);

        session.CurrentTrial.result["outcome"] = "tooslow";
        session.EndCurrentTrial();

        AudioSource.PlayClipAtPoint(failsound, new Vector3(0, 1.3f, 0), 1.0f);
    }
}
