using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAdjuster : MonoBehaviour
{
    public float increment = 0.01f;
    public KeyCode upkey;
    public KeyCode downkey;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("experiment_height"))
        {
            Vector3 newPos = transform.position;
            newPos.y = PlayerPrefs.GetFloat("experiment_height");
            transform.position = newPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upkey))
        {
            Vector3 newPos = transform.position + Vector3.up * increment;
            transform.position = newPos;
            PlayerPrefs.SetFloat("experiment_height", transform.position.y);
        }
        if (Input.GetKeyDown(downkey))
        {
            Vector3 newPos = transform.position + Vector3.down * increment;
            transform.position = newPos;
            PlayerPrefs.SetFloat("experiment_height", transform.position.y);
        }
    }
}
