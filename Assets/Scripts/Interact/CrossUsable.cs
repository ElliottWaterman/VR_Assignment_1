using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossUsable : UsableObject
{
    private Light areaLight;

    // Use this for initialization
    void Start()
    {
        this.interactKey = KeyCode.F;
        areaLight = GetComponent<Light>();
    }

    public override void OnUse()
    {
        // Toggle light use
        areaLight.enabled = (this.objectUsed ? false : true);
        this.ToggleObjectUsed();
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to pray";
    }
}
