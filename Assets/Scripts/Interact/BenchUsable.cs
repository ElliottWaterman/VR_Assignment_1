using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchUsable : UsableObject {

    GameObject player;
    GameObject mainCamera;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Destroy so display text does not show
        if (player == null || mainCamera == null)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        //Quaternion.Lerp()
    }

    public override void OnUse()
    {
        this.ToggleObjectUsed();

        if (objectUsed)
        {
            Debug.Log(player.transform.localRotation);
            //Debug.Log(player.transform.rotation);

            player.transform.position = new Vector3(-47.5978f, 20.14686f, 11.0146f);
            //player.transform.rotation = Quaternion.Euler(0.0f, -160.0f, 0.0f);
            //player.transform.rotation = new Quaternion(0.0f, -166.6f, 0.0f, 1.0f);

            // Test
            //player.transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);

            // Camera view point target
            //Quaternion target = Quaternion.Euler(0.0f, 175.0f, 0.0f);
            // Set player rotation to view point target
            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, target, 1);

            //player.transform.eulerAngles = new Vector3(0.0f, 175.0f, 0.0f);

            player.transform.localRotation = Quaternion.AngleAxis(175.0f, player.transform.up);

            //mainCamera.transform.localRotation = Quaternion.AngleAxis(0.5f, player.transform.up);

            Debug.Log(player.transform.localRotation);
            //Debug.Log(player.transform.rotation);
        }
        else
        {

        }

    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to sit";
    }
}
