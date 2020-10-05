using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class FeedbackController : MonoBehaviour
{
    public Transform cursorCopy;
    public AudioClip sound;
    // Start is called before the first frame update
    public void Present(Trial endedTrial)
    {
        
        string outcome = (string)endedTrial.result["outcome"];
        if (outcome != "hit" & outcome != "miss") return;

        float angle = (float)endedTrial.result["angle"];

        Vector3 newPos = Quaternion.Euler(0, angle, 0) * (Vector3.forward * 0.2f);

        newPos.y = cursorCopy.position.y;

        cursorCopy.gameObject.SetActive(true);
        cursorCopy.position = newPos;
        if (outcome == "hit")
        {
            AudioSource.PlayClipAtPoint(sound, newPos, 1.0f);
        }
    }
}
