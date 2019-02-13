﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossUsable : UsableObject
{
    private Light light;
    
    // Use this for initialization
    void Start()
    {
        this.interactKey = KeyCode.F;
        light = GetComponent<Light>();
    }

    public override void OnUse()
    {
        // Toggle light use
        light.enabled = (this.objectUsed ? false : true);
        this.ToggleObjectUsed();
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to pay respects";
    }
}
