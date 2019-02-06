using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWallUsable : UsableObject
{
    public Renderer wallObject;

    public Material stainedGlass;
    public Material creamWall;

    private bool secretUsed = false;

    public override void OnUse()
    {
        // Toggle secret found
        secretUsed = !secretUsed;

        // Secret used then set to stained glass, else set to cream wall
        wallObject.material = (secretUsed ? stainedGlass : creamWall);
    }

    public override void DisplayText()
    {
        // Display hint! Shh it's a secret!
        this.interactText.enabled = true;
        this.interactText.text = "You feel the urge to interact... (E)";
    }
}
