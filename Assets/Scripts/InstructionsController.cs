using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{
    public Text instructions;

    void Awake()
    {
        instructions.text = ""; // clear instructions until we start the session
    }

    // assign to On Session Begin event
    public void Present()
    {
        instructions.text = Session.instance.settings.GetString("instruction");
    }
}
