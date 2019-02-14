using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUsable : UsableObject
{
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void ChestAnimationControl(string direction)
    {
        animator.SetTrigger(direction);
    }

    public override void OnUse()
    {
        // Toggle the state of the chest lid, open = used, closed = not used
        this.ToggleObjectUsed();

        // Animate the opening or closing of the chest lid
        ChestAnimationControl((this.objectUsed) ? OPEN_STRING : CLOSE_STRING);
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to " 
            + (objectUsed ? CLOSE_STRING : OPEN_STRING) + " " + this.name;
    }
}
