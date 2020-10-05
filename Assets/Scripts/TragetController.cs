using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TragetController : MonoBehaviour
{
    public AudioClip audio;
    public Session session;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cursor")
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(audio, transform.position, 1.0f);
            Session.instance.EndCurrentTrial();
        }
    }
}
