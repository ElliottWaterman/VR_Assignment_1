using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUsable : UsableObject
{
    private const string OPEN_STRING = "Open";
    private const string CLOSE_STRING = "Close";

    private DoorColliderTrigger doorTrigger;
    private Animator animator;

	// Use this for initialization
	void Start () {
        doorTrigger = GetComponentInParent<DoorColliderTrigger>();
        animator = GetComponentInParent<Animator>();
    }

    private void DoorAnimationControl(string direction)
    {
        animator.SetTrigger(direction);
    }

    public override void OnUse()
    {
        // Check collider box in door trigger
        bool playerEntered = doorTrigger.HasPlayerEntered();
        bool doorOpen = doorTrigger.IsDoorOpen();

        // Door is CLOSED, player is present and pressed E
        if (playerEntered && !objectUsed)
        {
            objectUsed = !objectUsed;
            doorTrigger.SetDoorOpen(objectUsed);
            DoorAnimationControl(OPEN_STRING);
        }
        // Door is OPEN, player is present and pressed E
        else if (playerEntered && objectUsed)
        {
            objectUsed = !objectUsed;
            doorTrigger.SetDoorOpen(objectUsed);
            DoorAnimationControl(CLOSE_STRING);
        }
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " to " 
            + (objectUsed ? CLOSE_STRING : OPEN_STRING) + " " + this.name;
    }
}
