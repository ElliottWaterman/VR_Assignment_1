using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderTrigger : MonoBehaviour {

    private bool playerEntered;
    private bool doorOpen;

    // Use this for initialization
    void Start () {
        playerEntered = false;
        doorOpen = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = false;
        }

        // Use this to close door after player has left
        if (doorOpen)
        {
            //doorOpen = false;
            //DoorAnimationControl(CLOSE_STRING);
        }
    }

    public bool HasPlayerEntered()
    {
        return this.playerEntered;
    }

    public bool IsDoorOpen()
    {
        return this.doorOpen;
    }

    public void SetDoorOpen(bool state)
    {
        this.doorOpen = state;
    }
}
