using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossUsable : UsableObject
{
    // Use this for initialization
    void Start()
    {
        this.interactKey = KeyCode.F;
    }

    public override void OnUse()
    {
        // Toggle light use
        this.GetComponent<Light>().enabled = (objectUsed ? false : true);
        this.ToggleObjectUsed();
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to pay respects";
    }
}
