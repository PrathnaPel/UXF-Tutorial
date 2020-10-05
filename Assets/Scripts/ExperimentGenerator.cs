using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ExperimentGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public void Generate(Session session)
    {
        int numTrials = 10;
        session.CreateBlock(numTrials);
    }
}
