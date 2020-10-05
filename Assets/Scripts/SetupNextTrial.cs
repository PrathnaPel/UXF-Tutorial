using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupNextTrial : MonoBehaviour
{
    public MeshRenderer cursorMR;
    public GameObject cursorCopy;
    public GameObject startPoint;
    // Start is called before the first frame update
    public void DelayedSetup()
    {
        StartCoroutine(SetupSequence());
    }
    IEnumerator SetupSequence()
    {
        yield return new WaitForSeconds(0.5f);

        cursorMR.enabled = true;
        cursorCopy.SetActive(false);
        startPoint.SetActive(true);
    }
}
