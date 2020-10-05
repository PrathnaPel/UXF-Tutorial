using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform rightHand;
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        Vector3 handPos = rightHand.position;
        handPos.y = transform.position.y;
        transform.position = handPos;
    }
}
