using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets vertical movement from input keys (left, right, a, d)
        float translation = Input.GetAxis("Vertical") * speed;
        // Gets horizontal movement from input keys (up, down, w, s)
        float straffe = Input.GetAxis("Horizontal") * speed;
        // Difference from last frame
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        // Get back cursor if escape key is pressed
        if (Input.GetKeyDown("escape"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Debug.Log("Unlocked");
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Debug.Log("Locked");
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
