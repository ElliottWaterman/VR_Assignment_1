using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float WALKING_SPEED = 10.0f;
    private const float RUNNING_SPEED = WALKING_SPEED * 1.5f;

    public float speed = WALKING_SPEED;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Lock mouse into game screen
        Cursor.lockState = CursorLockMode.Locked;

        // Get rigidbody component of the player
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Holding shift key makes player run
        speed = (Input.GetKey(KeyCode.LeftShift) ? RUNNING_SPEED : WALKING_SPEED);

        // Gets vertical movement from input keys (left, right, a, d)
        float translation = Input.GetAxis("Vertical") * speed;
        // Gets horizontal movement from input keys (up, down, w, s)
        float straffe = Input.GetAxis("Horizontal") * speed;
        // Difference from last frame
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        // Get back cursor if escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Debug.Log("Cursor Unlocked");
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Debug.Log("Cursor Locked - Click mouse in screen");
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        // Pressing space makes player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0.0f, 400.0f, 0.0f));
        }
    }
}
